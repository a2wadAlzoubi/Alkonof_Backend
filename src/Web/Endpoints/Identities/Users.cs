using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Create;
using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Delete;
using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.SoftDelete;
using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Update;
using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.UpdatePassword;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetAll;
using Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByEmail;
using Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetById;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Identities;

public class Users : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", GetUsers);
        group.MapGet("/{id:guid}", GetUserById);
        group.MapGet("/email/{email}", GetUserByEmail);
        group.MapPost("/", CreateUser);
        group.MapPut("/{id:guid}", UpdateUser);
        group.MapPatch("/{id:guid}/soft-delete", SoftDeleteUser);
        group.MapDelete("/{id:guid}", DeleteUser);
        group.MapPatch("/update-password", UpdatePassword);
    }

    [EndpointSummary("Get all users")]
    public static async Task<Ok<List<UserDto>>> GetUsers(ISender sender)
    {
        var query = new GetUsersQuery();
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }

    [EndpointSummary("Get a user by ID")]
    public static async Task<Results<Ok<UserDto>, NotFound>> GetUserById(ISender sender, Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await sender.Send(query);
        return result is not null ? TypedResults.Ok(result) : TypedResults.NotFound();
    }

    [EndpointSummary("Get a user by Email")]
    public static async Task<Results<Ok<UserDto>, NotFound>> GetUserByEmail(ISender sender, string email)
    {
        var query = new GetUserByEmailQuery(email);
        var result = await sender.Send(query);
        return result is not null ? TypedResults.Ok(result) : TypedResults.NotFound();
    }

    [EndpointSummary("Create a new user")]
    public static async Task<Created<Guid>> CreateUser(ISender sender, [FromBody] CreateUserDto dto)
    {
        var command = new CreateUserCommand(dto);
        var newId = await sender.Send(command);
        return TypedResults.Created($"/api/Users/{newId}", newId);
    }

    [EndpointSummary("Update a user")]
    public static async Task<IResult> UpdateUser(ISender sender, [FromBody] UserDto dto)
    {

        var command = new UpdateUserCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Update user password")]
    public static async Task<IResult> UpdatePassword(ISender sender, [FromBody] UpdatePasswordDto dto)
    {
        var command = new UpdatePasswordCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Soft delete a user")]
    public static async Task<IResult> SoftDeleteUser(ISender sender, Guid id)
    {
        var command = new SoftDeleteUserCommand(id);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Permanently delete a user")]
    public static async Task<IResult> DeleteUser(ISender sender, Guid id)
    {
        var command = new DeleteUserCommand(id);
        await sender.Send(command);
        return TypedResults.NoContent();
    }
}
