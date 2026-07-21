using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Create;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Remove;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Update;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetAll;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class PermissionGrops : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", GetPermissionGrops);
        group.MapPost("/", CreatePermissionGrop);
        group.MapPut("/{id:guid}", UpdatePermissionGrop);
        group.MapDelete("/{id:guid}", RemovePermissionGrop);
    }

    [EndpointSummary("Get all permission groups")]
    public static async Task<Ok<List<PermissionGropDto>>> GetPermissionGrops(ISender sender)
    {
        var query = new GetPermissionGropsQuery();
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }

    [EndpointSummary("Create a new permission group")]
    public static async Task<Created<Guid>> CreatePermissionGrop(ISender sender, [FromBody] CreatePermissionGropDto dto)
    {
        var command = new CreatePermissionGropCommand(dto);
        var newId = await sender.Send(command);
        return TypedResults.Created($"/api/PermissionGrops/{newId}", newId);
    }

    [EndpointSummary("Update a permission group")]
    public static async Task<IResult> UpdatePermissionGrop(ISender sender, Guid id, [FromBody] UpdatePermissionGropDto dto)
    {
        if (id != dto.Id)
        {
            return TypedResults.BadRequest("ID in URL and body do not match.");
        }

        var command = new UpdatePermissionGropCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Remove a permission group")]
    public static async Task<IResult> RemovePermissionGrop(ISender sender, Guid id)
    {
        var command = new RemovePermissionGropCommand(id);
        await sender.Send(command);
        return TypedResults.NoContent();
    }
}
