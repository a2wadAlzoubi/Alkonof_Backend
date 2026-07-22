using Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeContractStatus;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeProjectType;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.CreateContract;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.RemoveContract;
using Alkonof_Backend.Application.Modulers.Contracts.Commands.UpdateContract;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByCustomerId;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractById;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByProjectId;
using Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContracts;
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

        group.MapPost("/", async (ISender sender, CreateContractCommand command) =>
        {
            var id = await sender.Send(command);
            return Results.Created($"/api/contracts/{id}", id);
        });

        group.MapPut("/{id:guid}", async (ISender sender, Guid id, UpdateContractCommand command) =>
        {
            if (id != command.Id)
            {
                return Results.BadRequest("ID mismatch");
            }
            await sender.Send(command);
            return Results.NoContent();
        });

        group.MapDelete("/{id:guid}", async (ISender sender, Guid id) =>
        {
            await sender.Send(new RemoveContractCommand(id));
            return Results.NoContent();
        });

        group.MapPatch("/{id:guid}/status", async (ISender sender, Guid id, ChangeContractStatusCommand command) =>
        {
            if (id != command.Id)
            {
                return Results.BadRequest("ID mismatch");
            }
            await sender.Send(command);
            return Results.NoContent();
        });

        group.MapPatch("/{id:guid}/project-type", async (ISender sender, Guid id, ChangeProjectTypeCommand command) =>
        {
            if (id != command.Id)
            {
                return Results.BadRequest("ID mismatch");
            }
            await sender.Send(command);
            return Results.NoContent();
        });

        group.MapGet("/{id:guid}", async (ISender sender, Guid id) =>
        {
            var contract = await sender.Send(new GetContractByIdQuery(id));
            return contract is not null ? Results.Ok(contract) : Results.NotFound();
        });

        group.MapGet("/customer/{customerId:guid}", async (ISender sender, Guid customerId) =>
        {
            var contracts = await sender.Send(new GetContractByCustomerIdQuery(customerId));
            return Results.Ok(contracts);
        });

        group.MapGet("/project/{projectId:guid}", async (ISender sender, Guid projectId) =>
        {
            var contracts = await sender.Send(new GetContractByProjectIdQuery(projectId));
            return Results.Ok(contracts);
        });

        group.MapGet("/", async (ISender sender) =>
        {
            var contracts = await sender.Send(new GetContractsQuery());
            return Results.Ok(contracts);
        });
    }
}
