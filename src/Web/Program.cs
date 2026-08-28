// This file configures and starts the main web service.
using Alkonof_Backend.Infrastructure.Data;
using Alkonof_Backend.Infrastructure.Hangfire;
using Hangfire;
using Scalar.AspNetCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();

builder.AddKeyVaultIfConfigured();
builder.AddApplicationServices(builder.Configuration);
builder.AddInfrastructureServices(builder.Configuration);
builder.AddWebServices();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    await app.InitialiseDatabaseAsync();
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors(static builder => 
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());

app.UseFileServer();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.WithOpenApiRoutePattern("/openapi/{documentName}.json");
});

app.UseExceptionHandler(options => { });

// Use Hangfire Dashboard
app.UseHangfireDashboard("/hangfire");

// Schedule recurring jobs using the centralized scheduler
RecurringJobsScheduler.ScheduleJobs(app.Services);

app.Map("/", () => Results.Redirect("/scalar"));

app.MapDefaultEndpoints();
app.MapEndpoints(typeof(Program).Assembly);


app.Run();
