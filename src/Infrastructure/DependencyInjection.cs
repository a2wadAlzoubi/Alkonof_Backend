using System.Globalization;
using System.Text;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Infrastructure.Consumers;
using Alkonof_Backend.Infrastructure.Data;
using Alkonof_Backend.Infrastructure.Data.Interceptors;
using Alkonof_Backend.Infrastructure.Identity;
using Alkonof_Backend.Infrastructure.Services;
using Application.Abstractions.JWT;
using Hangfire;
using Infrastructure.Abstraction;
using Infrastructure.JWT;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Resend;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder , IConfiguration configuration)
    {
        var connectionString = builder.Configuration.GetConnectionString(Services.Database);
        Guard.Against.Null(connectionString, message: $"Connection string '{Services.Database}' not found.");

        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        });


        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        builder.Services.AddScoped<ApplicationDbContextInitialiser>();

        builder.Services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        builder.Services.AddAuthorizationBuilder();

        builder.Services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        builder.Services.AddSingleton(TimeProvider.System);


        builder.Services.AddHttpClient<ResendClient>();

        // Resend Settings
        builder.Services.AddOptions<ResendSettings>()
            .BindConfiguration(ResendSettings.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Resend
        builder.Services.AddResend(options =>
        {
            options.ApiToken = builder.Configuration
                .GetRequiredSection(ResendSettings.SectionName)
                .GetValue<string>(nameof(ResendSettings.ApiKey))
                ?? throw new InvalidOperationException(
                    "Resend:ApiKey is not configured.");
        });

        builder.Services.AddTransient<IResend, ResendClient>();
        builder.Services.AddTransient<IEmailSender, ResendEmailSender>();
        builder.Services.AddTransient<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
        builder.Services.AddScoped<IJwtExtractor, JwtExtractor>();
        builder.Services.AddScoped<IGenerateRefreshToken, GenerateRefreshToken>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
        {
            opts.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAlgorithms = [SecurityAlgorithms.HmacSha512],
                // ValidIssuer = configuration["JwtOptions:Issuer"],
                // ValidAudience = configuration["JwtOptions:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Key"]!)),
                ClockSkew = TimeSpan.Zero
            };
            //opts.TokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = !string.IsNullOrWhiteSpace(issuer),
            //    ValidIssuer = issuer,
            //    ValidateAudience = !string.IsNullOrWhiteSpace(audience),
            //    ValidAudience = audience,
            //    ValidateLifetime = true,
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            //    ClockSkew = TimeSpan.Zero,
            //    ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 }
            //};
        });

        builder.Services.AddHttpContextAccessor();
        
        // MassTransit
        builder.Services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<ApplicationDbContext>(o =>
            {
                o.QueryDelay = TimeSpan.FromSeconds(10);

                o.UseSqlServer();
                o.UseBusOutbox();
            });
            
            x.SetKebabCaseEndpointNameFormatter();

            x.AddConsumers(typeof(InReviewCustomerBookingConsumer).Assembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("messaging"));
                
                cfg.ConfigureEndpoints(context);
            });
        });

        // Add Hangfire services.
        builder.Services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString));

        // Add the processing server as IHostedService
        builder.Services.AddHangfireServer();
    }
}
