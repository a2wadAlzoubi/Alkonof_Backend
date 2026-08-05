using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGrops;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGropsByOperation;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class PermissionGrops : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("PermissionGrops");

        group.MapGet("/", GetPermissionGrops)
            .WithName(nameof(GetPermissionGrops))
            .WithSummary("Get all permission groups.");

        group.MapGet("/{operationPermission}", GetPermissionGropsByOperation)
            .WithName(nameof(GetPermissionGropsByOperation))
            .WithSummary("Get permission groups by operation.");
    }

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
}
