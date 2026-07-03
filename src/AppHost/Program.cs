using Alkonof_Backend.Shared;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddAzureContainerAppEnvironment("aca-env");

var jwtKey = builder.AddParameter("JwtKey");
//var jwtIssuer = builder.AddParameter("JwtIssuer");
//var jwtAudience = builder.AddParameter("JwtAudience");
//var web = builder
//    .AddProject<Projects.Web>(Services.WebApi)


var databaseServer = builder
    .AddSqlServer(Services.Database);

var web = builder.AddProject<Projects.Web>(Services.WebApi)
    .WithReference(databaseServer)
    .WaitFor(databaseServer)
    .WithExternalHttpEndpoints()
    .WithAspNetCoreEnvironment()
    .WithUrlForEndpoint("http", url =>
    {
        url.DisplayText = "Scalar API Reference";
        url.Url = "/scalar";
    }).WithEnvironment("JwtOptions__Key", jwtKey)
    //.WithEnvironment("JwtOptions__Issuer", jwtIssuer)
    //.WithEnvironment("JwtOptions__Audience", jwtAudience)
    ;


builder.Build().Run();
