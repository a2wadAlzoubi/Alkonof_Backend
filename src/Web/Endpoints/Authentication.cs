using Alkonof_Backend.Application.TodoItems.Commands.CreateTodoItem;
using Alkonof_Backend.Application.TodoItems.Commands.DeleteTodoItem;
using Alkonof_Backend.Application.TodoItems.Commands.UpdateTodoItem;
using Alkonof_Backend.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Alkonof_Backend.Domain.Entities.Identity;
using Application.Authentication.Dtos;
using Application.Authentication.Register;
using Application.Authentication.SignIn;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints;

public class Authentication : IEndpointGroup
{
    
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/register",Register).AllowAnonymous();
        groupBuilder.MapPost("/login", Login).AllowAnonymous();
    }

    [EndpointSummary("Register a new user")]
    [EndpointDescription("Registers a new user using the provided details and returns the ID of the created user.")]
    public static async Task<Created<RefreshTokenResponce>> Register(ISender sender, [FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request);
        var RefreshToken = await sender.Send(command, CancellationToken.None);

        return TypedResults.Created($"/{nameof(User)}/register", RefreshToken);
    }
    [EndpointSummary("Login")]
    [EndpointDescription("Login a user using the provided details and returns Refresh Token.")]
    public static async Task<Created<RefreshTokenResponce>> Login(ISender sender, [FromBody] LoginRequest request)
    {
        var command = new LoginCommand(request);
        var RefreshToken = await sender.Send(command, CancellationToken.None);

        return TypedResults.Created($"/{nameof(User)}/login", RefreshToken);
    }

}
