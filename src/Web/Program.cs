// This file configures and starts the main web service.
using Alkonof_Backend.Infrastructure.Data;
using Alkonof_Backend.Infrastructure.Hangfire;
using Hangfire;
using Scalar.AspNetCore;

// --- Robust .env file loading with diagnostics ---
try
{
    var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
    var currentDir = entryAssembly != null 
        ? new DirectoryInfo(Path.GetDirectoryName(entryAssembly.Location)!) 
        : new DirectoryInfo(AppContext.BaseDirectory);

    Console.WriteLine($"[ENV_LOADER] Starting directory: {currentDir.FullName}");

    while (currentDir != null && !currentDir.GetFiles("*.sln").Any())
    {
        currentDir = currentDir.Parent;
    }

    if (currentDir != null)
    {
        var dotEnvPath = Path.Combine(currentDir.FullName, ".env");
        Console.WriteLine($"[ENV_LOADER] Solution root found. Checking for .env file at: {dotEnvPath}");

        if (File.Exists(dotEnvPath))
        {
            Console.WriteLine($"[ENV_LOADER] SUCCESS: Found .env file. Loading...");
            DotNetEnv.Env.Load(dotEnvPath);
            Console.WriteLine($"[ENV_LOADER] LOADED. Verifying variables...");
            var apiKey = Environment.GetEnvironmentVariable("Resend__ApiKey");
            var fromAddress = Environment.GetEnvironmentVariable("Resend__FromAddress");

            if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(fromAddress))
            {
                Console.WriteLine($"[ENV_LOADER] SUCCESS: 'Resend__ApiKey' and 'Resend__FromAddress' are present in the environment.");
            }
            else
            {
                Console.WriteLine($"[ENV_LOADER] FAILURE: One or more Resend variables were NOT found in the environment after loading.");
            }
        }
        else
        {
            Console.WriteLine($"[ENV_LOADER] ERROR: .env file not found at expected path.");
        }
    }
    else
    {
        Console.WriteLine("[ENV_LOADER] ERROR: Could not find solution root directory (.sln file).");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"[ENV_LOADER] CRITICAL FAILURE: An exception occurred during .env loading: {ex.Message}");
}
// --- End of robust loading ---

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
