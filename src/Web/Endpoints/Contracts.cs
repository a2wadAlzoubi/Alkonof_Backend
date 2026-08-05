using Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeContractStatus;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeProjectType;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.CreateContract;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.RemoveContract;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.UpdateContract;
using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByCustomerId;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractById;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByProjectId;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContracts;
using Alkonof_Backend.Domain.Entities.Contracts.Enum;
using Alkonof_Backend.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Alkonof_Backend.Web.Endpoints;

public class Contracts : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("Contracts");

        // Commands
        group.MapPost("/", CreateContract)
            .WithName(nameof(CreateContract))
            .WithSummary("Create a new contract.");

        group.MapPut("/{id:guid}", UpdateContract)
            .WithName(nameof(UpdateContract))
            .WithSummary("Update an existing contract.");

        group.MapDelete("/{id:guid}", RemoveContract)
            .WithName(nameof(RemoveContract))
            .WithSummary("Remove a contract.");

        group.MapPatch("/{id:guid}/status", ChangeContractStatus)
            .WithName(nameof(ChangeContractStatus))
            .WithSummary("Change the status of a contract.");

        group.MapPatch("/{id:guid}/project-type", ChangeProjectType)
            .WithName(nameof(ChangeProjectType))
            .WithSummary("Change the project type of a contract.");

        // Queries
        group.MapGet("/", GetContracts)
            .WithName(nameof(GetContracts))
            .WithSummary("Get all contracts.");

        group.MapGet("/{id:guid}", GetContractById)
            .WithName(nameof(GetContractById))
            .WithSummary("Get a contract by its ID.");

        group.MapGet("/customer/{customerId:guid}", GetContractsByCustomerId)
            .WithName(nameof(GetContractsByCustomerId))
            .WithSummary("Get contracts by customer ID.");

        group.MapGet("/project/{projectId:guid}", GetContractsByProjectId)
            .WithName(nameof(GetContractsByProjectId))
            .WithSummary("Get contracts by project ID.");
    }

    // Command Handlers
    public static async Task<IResult> CreateContract(ISender sender, CreateContractCommand command)
    {
        var id = await sender.Send(command);
        return Results.Created($"/api/contracts/{id}", id);
    }

    public static async Task<IResult> UpdateContract(ISender sender, Guid id, UpdateContractCommand command)
    {
        if (id != command.Id) return Results.BadRequest("ID mismatch");
        await sender.Send(command);
        return Results.NoContent();
    }

    public static async Task<IResult> RemoveContract(ISender sender, Guid id)
    {
        await sender.Send(new RemoveContractCommand(id));
        return Results.NoContent();
    }

    public static async Task<IResult> ChangeContractStatus(ISender sender, Guid id, ContractStatus status)
    {
        await sender.Send(new ChangeContractStatusCommand(id, status));
        return Results.NoContent();
    }

    public static async Task<IResult> ChangeProjectType(ISender sender, Guid id, ProjectType type)
    {
        await sender.Send(new ChangeProjectTypeCommand(id, type));
        return Results.NoContent();
    }

    // Query Handlers
    public static async Task<IResult> GetContracts(ISender sender)
    {
        var contracts = await sender.Send(new GetContractsQuery());
        return Results.Ok(contracts);
    }

    public static async Task<IResult> GetContractById(ISender sender, Guid id)
    {
        var contract = await sender.Send(new GetContractByIdQuery(id));
        return contract is not null ? Results.Ok(contract) : Results.NotFound();
    }

    public static async Task<IResult> GetContractsByCustomerId(ISender sender, Guid customerId)
    {
        var contracts = await sender.Send(new GetContractByCustomerIdQuery(customerId));
        return Results.Ok(contracts);
    }

    public static async Task<IResult> GetContractsByProjectId(ISender sender, Guid projectId)
    {
        var contracts = await sender.Send(new GetContractByProjectIdQuery(projectId));
        return Results.Ok(contracts);
    }
}
