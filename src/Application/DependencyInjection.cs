using System.Configuration;
using System.Reflection;
using Alkonof_Backend.Application.Common.Behaviours;
using Application.Abstractions;
using Application.Abstractions.JWT;
using Application.Entities.Users.Services;
using Application.Options;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder , IConfiguration configuration)
    {
        builder.Services.AddAutoMapper(cfg =>
        cfg.AddMaps(Assembly.GetExecutingAssembly()));

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenRequestPreProcessor(typeof(LoggingBehaviour<>));
            cfg.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            cfg.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
        });
        builder.Services.AddScoped<IPasswordService, PasswordService>();
        //builder.Services.AddScoped<ICurrentUserProvider>();
        //builder.Services.AddScoped<IJwtGenerator>();
        // Mapster config (اختياري لكنه مهم)
        var config = TypeAdapterConfig.GlobalSettings;

        // تسجيل mapper الصحيح
        builder.Services.AddSingleton(config);
        builder.Services.AddScoped<MapsterMapper.IMapper, ServiceMapper>();
        ArgumentNullException.ThrowIfNull(configuration);
        builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
    }
}
