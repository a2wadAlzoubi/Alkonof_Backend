using Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Commands;
using Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class GrantPermissions : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/", GrantPermissionToUser);
    }

    [EndpointSummary("Grant a permission to a user")]
    public static async Task<IResult> GrantPermissionToUser(ISender sender, [FromBody] GrantPermissionDto dto)
    {
        var command = new GrantPermissionCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }
}
