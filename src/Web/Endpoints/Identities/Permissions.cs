using Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Create;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Remove;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Update;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetAll;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class Permissions : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", GetPermissions);
        group.MapPost("/", CreatePermission);
        group.MapPut("/{id:guid}", UpdatePermission);
        group.MapDelete("/{id:guid}", RemovePermission);
    }

    [EndpointSummary("Get all permissions")]
    public static async Task<Ok<List<PermissionDto>>> GetPermissions(ISender sender)
    {
        var query = new GetPermissionsQuery();
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }

    [EndpointSummary("Create a new permission")]
    public static async Task<Created<Guid>> CreatePermission(ISender sender, [FromBody] CreatePermissionDto dto)
    {
        var command = new CreatePermissionCommand(dto);
        var newId = await sender.Send(command);
        return TypedResults.Created($"/api/Permissions/{newId}", newId);
    }

    [EndpointSummary("Update a permission")]
    public static async Task<IResult> UpdatePermission(ISender sender, Guid id, [FromBody] UpdatePermissionDto dto)
    {
        if (id != dto.Id)
        {
            return TypedResults.BadRequest("ID in URL and body do not match.");
        }

        var command = new UpdatePermissionCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Remove a permission")]
    public static async Task<IResult> RemovePermission(ISender sender, Guid id)
    {
        var command = new RemovePermissionCommand(id);
        await sender.Send(command);
        return TypedResults.NoContent();
    }
}
