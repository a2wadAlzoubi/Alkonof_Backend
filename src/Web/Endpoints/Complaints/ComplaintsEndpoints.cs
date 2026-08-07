using Alkonof_Backend.Application.Modulers.Complaints.Commands.ChangeComplainStatus;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.CreateComplain;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.CreateResolution;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.RemoveComplain;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.RemoveResolution;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.SetReferenceType;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.UpdateComplain;
using Alkonof_Backend.Application.Modulers.Complaints.Commands.UpdateResolution;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainById;
using Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainByComplainStatus;
using Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainByReferenceType;
using Alkonof_Backend.Application.Modulers.Complaints.Queries.GetResolutionById;
using Alkonof_Backend.Application.Modulers.Complaints.Queries.GetResolutionByComplainId;
using Alkonof_Backend.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Alkonof_Backend.Domain.Entities.Complains.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Web.Endpoints.Complaints;

public record ChangeComplainStatusRequest(Guid Id, ComplainStatus Status);
public record SetReferenceTypeRequest(Guid Id, ReferenceType ReferenceType);

public class ComplaintsEndpoints : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("Complaints");

        // Complain Commands
        group.MapPost("/", CreateComplain)
            .WithName(nameof(CreateComplain))
            .WithSummary("Create a new complain.");

        group.MapPut("/{id:guid}", UpdateComplain)
            .WithName(nameof(UpdateComplain))
            .WithSummary("Update an existing complain.");

        group.MapDelete("/{id:guid}", RemoveComplain)
            .WithName(nameof(RemoveComplain))
            .WithSummary("Remove a complain.");

        group.MapPatch("/{id:guid}/status", ChangeComplainStatus)
            .WithName(nameof(ChangeComplainStatus))
            .WithSummary("Change complain status.");

        group.MapPatch("/{id:guid}/reference-type", SetReferenceType)
            .WithName(nameof(SetReferenceType))
            .WithSummary("Set complain reference type.");

        // Resolution Commands
        group.MapPost("/resolutions", CreateResolution)
            .WithName(nameof(CreateResolution))
            .WithSummary("Create a new resolution.");

        group.MapPut("/resolutions/{id:guid}", UpdateResolution)
            .WithName(nameof(UpdateResolution))
            .WithSummary("Update an existing resolution.");

        group.MapDelete("/resolutions/{id:guid}", RemoveResolution)
            .WithName(nameof(RemoveResolution))
            .WithSummary("Remove a resolution.");

        // Complain Queries
        group.MapGet("/{id:guid}", GetComplainById)
            .WithName(nameof(GetComplainById))
            .WithSummary("Get a complain by ID.");

        group.MapGet("/status/{status}", GetComplainByComplainStatus)
            .WithName(nameof(GetComplainByComplainStatus))
            .WithSummary("Get complains by status.");

        group.MapGet("/reference-type/{referenceType}", GetComplainByReferenceType)
            .WithName(nameof(GetComplainByReferenceType))
            .WithSummary("Get complains by reference type.");

        // Resolution Queries
        group.MapGet("/resolutions/{id:guid}", GetResolutionById)
            .WithName(nameof(GetResolutionById))
            .WithSummary("Get a resolution by ID.");

        group.MapGet("/complains/{complintId:guid}/resolutions", GetResolutionByComplainId)
            .WithName(nameof(GetResolutionByComplainId))
            .WithSummary("Get all resolutions for a specific complain.");
    }

    // Complain Handlers
    private static async Task<Results<Ok<Guid?>, BadRequest<string>>> CreateComplain(ISender sender, CreateComplainDto dto)
    {
        var id = await sender.Send(new CreateComplainCommand(dto));
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateComplain(ISender sender, Guid id, UpdateComplainDto dto)
    {
        await sender.Send(new UpdateComplainCommand(dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RemoveComplain(ISender sender, Guid id)
    {
        await sender.Send(new RemoveComplainCommand(id));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> ChangeComplainStatus(ISender sender, Guid id, ChangeComplainStatusRequest request)
    {
        await sender.Send(new ChangeComplainStatusCommand(new ChangeComplainStatusDto { Id = id, Status = request.Status }));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> SetReferenceType(ISender sender, Guid id, SetReferenceTypeRequest request)
    {
        await sender.Send(new SetReferenceTypeCommand(new SetReferenceTypeDto { Id = id, ReferenceType = request.ReferenceType }));
        return TypedResults.Ok();
    }

    // Resolution Handlers
    private static async Task<Results<Ok<Guid?>, BadRequest<string>>> CreateResolution(ISender sender, CreateResolutionDto dto)
    {
        var id = await sender.Send(new CreateResolutionCommand(dto));
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateResolution(ISender sender, Guid id, UpdateResolutionDto dto)
    {
        await sender.Send(new UpdateResolutionCommand(dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RemoveResolution(ISender sender, Guid id)
    {
        await sender.Send(new RemoveResolutionCommand(id));
        return TypedResults.Ok();
    }

    // Query Handlers
    private static async Task<Results<Ok<ComplainDto>, NotFound>> GetComplainById(ISender sender, Guid id)
    {
        var complain = await sender.Send(new GetComplainByIdQuery(id));
        return complain == null ? TypedResults.NotFound() : TypedResults.Ok(complain);
    }

    private static async Task<Ok<List<ComplainDto>>> GetComplainByComplainStatus(ISender sender, ComplainStatus status)
    {
        var complains = await sender.Send(new GetComplainByComplainStatusQuery(status));
        return TypedResults.Ok(complains);
    }

    private static async Task<Ok<List<ComplainDto>>> GetComplainByReferenceType(ISender sender, ReferenceType referenceType)
    {
        var complains = await sender.Send(new GetComplainByReferenceTypeQuery(referenceType));
        return TypedResults.Ok(complains);
    }

    private static async Task<Results<Ok<ResolutionDto>, NotFound>> GetResolutionById(ISender sender, Guid id)
    {
        var resolution = await sender.Send(new GetResolutionByIdQuery(id));
        return resolution == null ? TypedResults.NotFound() : TypedResults.Ok(resolution);
    }

    private static async Task<Ok<List<ResolutionDto>>> GetResolutionByComplainId(ISender sender, Guid complintId)
    {
        var resolutions = await sender.Send(new GetResolutionByComplainIdQuery(complintId));
        return TypedResults.Ok(resolutions);
    }
}
