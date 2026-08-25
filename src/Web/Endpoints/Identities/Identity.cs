using Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos;
using Alkonof_Backend.Application.Modulers.Identities.Authentication.Login;
using Alkonof_Backend.Application.Modulers.Identities.Authentication.Register;
using Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Commands;
using Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Dtos;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGrops;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGropsByOperation;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissions;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissionsByType;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class Identity : IEndpointGroup
{

    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("Identity").RequireAuthorization();

        // Authentication Endpoints
        group.MapPost("/register", Register)
            .WithName(nameof(Register))
            .WithSummary("Register a new user")
            .WithDescription("Registers a new user using the provided details and returns the ID of the created user.")
            .AllowAnonymous();

        group.MapPost("/login", Login)
            .WithName(nameof(Login))
            .WithSummary("Login")
            .WithDescription("Login a user using the provided details and returns Refresh Token.")
            .AllowAnonymous();

        // Grant Permission to User Endpoint
        group.MapPost("/grant-permission", GrantPermissionToUser)
            .WithName(nameof(GrantPermissionToUser))
            .WithSummary("Grant a permission to a user");

        // Permission Groups Endpoints
        group.MapGet("/permission-groups", GetPermissionGrops)
            .WithName(nameof(GetPermissionGrops))
            .WithSummary("Get all permission groups.");

        group.MapGet("/permission-groups/{operationPermission}", GetPermissionGropsByOperation)
            .WithName(nameof(GetPermissionGropsByOperation))
            .WithSummary("Get permission groups by operation.");

        // Permissions Endpoints
        group.MapGet("/permissions", GetPermissions)
            .WithName(nameof(GetPermissions))
            .WithSummary("Get all permissions.");

        group.MapGet("/permissions/{permissionType}", GetPermissionsByType)
            .WithName(nameof(GetPermissionsByType))
            .WithSummary("Get permissions by type.");
    }

    // Authentication Endpoints
    public static async Task<Created<RefreshTokenResponce>> Register(ISender sender, [FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request);
        var refreshToken = await sender.Send(command, CancellationToken.None);

        return TypedResults.Created($"/{nameof(User)}/register", refreshToken);
    }

    public static async Task<Created<RefreshTokenResponce>> Login(ISender sender, [FromBody] LoginRequest request)
    {
        var command = new LoginCommand(request);
        var refreshToken = await sender.Send(command, CancellationToken.None);

        return TypedResults.Created($"/{nameof(User)}/login", refreshToken);
    }

    // Grant Permission to User Endpoint
    public static async Task<IResult> GrantPermissionToUser(ISender sender, [FromBody] GrantPermissionDto dto)
    {
        var command = new GrantPermissionCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    // Permission Groups Endpoints
    public static async Task<IResult> GetPermissionGrops(ISender sender)
    {
        var permissionGrops = await sender.Send(new GetPermissionGropsQuery());
        return Results.Ok(permissionGrops);
    }

    public static async Task<IResult> GetPermissionGropsByOperation(ISender sender, OperationPermission operationPermission)
    {
        var permissionGrops = await sender.Send(new GetPermissionGropsByOperationQuery(operationPermission));
        return Results.Ok(permissionGrops);
    }


    // Permissions Endpoints
    public static async Task<IResult> GetPermissions(ISender sender)
    {
        var permissions = await sender.Send(new GetPermissionsQuery());
        return Results.Ok(permissions);
    }

    public static async Task<IResult> GetPermissionsByType(ISender sender, PermissionType permissionType)
    {
        var permissions = await sender.Send(new GetPermissionsByTypeQuery(permissionType));
        return Results.Ok(permissions);
    }
}
