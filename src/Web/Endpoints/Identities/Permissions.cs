using Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissions;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissionsByType;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class Permissions : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("Permissions");

        group.MapGet("/", GetPermissions)
            .WithName(nameof(GetPermissions))
            .WithSummary("Get all permissions.");

        group.MapGet("/{permissionType}", GetPermissionsByType)
            .WithName(nameof(GetPermissionsByType))
            .WithSummary("Get permissions by type.");
    }

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
