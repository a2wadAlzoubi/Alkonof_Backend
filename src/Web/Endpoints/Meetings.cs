using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.AgreementRechedMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CancellMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CompleteMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CreateMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.NeedAnotherMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.RejectedMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.RemoveMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.SetUserStatusMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.UpdateMeeting;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetAgreementRechedMeetings;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingById;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingByUserId;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetings;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingsByStatusDate;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingByUserIdStatusDate;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetNeededAnotherMeetings;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetRejetedMeetings;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using Alkonof_Backend.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace Alkonof_Backend.Web.Endpoints;

public record SetUserStatusMeetingRequest(Guid UserId, MeetingUserStatus Status, bool IsCustomer);

public class Meetings : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("Meetings");

        // Commands
        group.MapPost("/", CreateMeeting)
            .WithName(nameof(CreateMeeting))
            .WithSummary("Create a new meeting.");

        group.MapPut("/{id:guid}", UpdateMeeting)
            .WithName(nameof(UpdateMeeting))
            .WithSummary("Update an existing meeting.");

        group.MapDelete("/{id:guid}", RemoveMeeting)
            .WithName(nameof(RemoveMeeting))
            .WithSummary("Remove a meeting.");

        group.MapPatch("/{meetingId:guid}/user-status", SetUserStatusMeeting)
            .WithName(nameof(SetUserStatusMeeting))
            .WithSummary("Set user status for a meeting.");

        group.MapPatch("/{meetingId:guid}/cancell", CancellMeeting)
            .WithName(nameof(CancellMeeting))
            .WithSummary("Cancell a meeting.");

        group.MapPatch("/{meetingId:guid}/complete", CompleteMeeting)
            .WithName(nameof(CompleteMeeting))
            .WithSummary("Complete a meeting.");

        group.MapPatch("/{meetingId:guid}/agreement-reached", AgreementRechedMeeting)
            .WithName(nameof(AgreementRechedMeeting))
            .WithSummary("Mark meeting as agreement reached.");

        group.MapPatch("/{meetingId:guid}/rejected", RejectedMeeting)
            .WithName(nameof(RejectedMeeting))
            .WithSummary("Mark meeting as rejected.");

        group.MapPatch("/{meetingId:guid}/need-another", NeedAnotherMeeting)
            .WithName(nameof(NeedAnotherMeeting))
            .WithSummary("Mark meeting as needing another meeting.");

        // Queries
        group.MapGet("/{id:guid}", GetMeetingById)
            .WithName(nameof(GetMeetingById))
            .WithSummary("Get a meeting by ID.");

        group.MapGet("/user/{userId:guid}", GetMeetingsByUserId)
            .WithName(nameof(GetMeetingsByUserId))
            .WithSummary("Get meetings by user ID.");

        group.MapGet("/", GetMeetings)
            .WithName(nameof(GetMeetings))
            .WithSummary("Get all meetings.");

        group.MapGet("/agreement-reached", GetAgreementRechedMeetings)
            .WithName(nameof(GetAgreementRechedMeetings))
            .WithSummary("Get meetings with agreement reached.");

        group.MapGet("/rejected", GetRejetedMeetings)
            .WithName(nameof(GetRejetedMeetings))
            .WithSummary("Get rejected meetings.");

        group.MapGet("/needed-another", GetNeededAnotherMeetings)
            .WithName(nameof(GetNeededAnotherMeetings))
            .WithSummary("Get meetings that need another meeting.");
        
        group.MapGet("/status-date", GetMeetingsByStatusDate)
            .WithName(nameof(GetMeetingsByStatusDate))
            .WithSummary("Get meetings by status and date.");

        group.MapGet("/user/{userId:guid}/status-date", GetMeetingByUserIdStatusDate)
            .WithName(nameof(GetMeetingByUserIdStatusDate))
            .WithSummary("Get meetings by user ID, status, and date.");
    }

    private static async Task<Results<Ok<Guid>, BadRequest<string>>> CreateMeeting(ISender sender, CreateMeetingDto dto)
    {
        var id = await sender.Send(new CreateMeetingCommand(dto));
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateMeeting(ISender sender, Guid id, MeetingDto dto)
    {
        await sender.Send(new UpdateMeetingCommand(id, dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RemoveMeeting(ISender sender, Guid id)
    {
        await sender.Send(new RemoveMeetingCommand(id));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> SetUserStatusMeeting(ISender sender, Guid meetingId, SetUserStatusMeetingRequest request)
    {
        await sender.Send(new SetUserStatusMeetingCommand(meetingId, request.UserId, request.Status, request.IsCustomer));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> CancellMeeting(ISender sender, Guid meetingId)
    {
        await sender.Send(new CancellMeetingCommand(meetingId));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> CompleteMeeting(ISender sender, Guid meetingId)
    {
        await sender.Send(new CompleteMeetingCommand(meetingId));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> AgreementRechedMeeting(ISender sender, Guid meetingId)
    {
        await sender.Send(new AgreementRechedMeetingCommand(meetingId));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RejectedMeeting(ISender sender, Guid meetingId)
    {
        await sender.Send(new RejectedMeetingCommand(meetingId));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> NeedAnotherMeeting(ISender sender, Guid meetingId)
    {
        await sender.Send(new NeedAnotherMeetingCommand(meetingId));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok<MeetingDto>, NotFound>> GetMeetingById(ISender sender, Guid id)
    {
        var meeting = await sender.Send(new GetMeetingByIdQuery(id));
        return TypedResults.Ok(meeting);
    }

    private static async Task<Ok<List<MeetingDto>>> GetMeetingsByUserId(ISender sender, Guid userId)
    {
        var meetings = await sender.Send(new GetMeetingByUserIdQuery(userId));
        return TypedResults.Ok(meetings);
    }

    private static async Task<Ok<List<MeetingDto>>> GetMeetings(ISender sender)
    {
        var meetings = await sender.Send(new GetMeetingsQuery());
        return TypedResults.Ok(meetings);
    }

    private static async Task<Ok<List<MeetingDto>>> GetAgreementRechedMeetings(ISender sender)
    {
        var meetings = await sender.Send(new GetAgreementRechedMeetingsQuery());
        return TypedResults.Ok(meetings);
    }

    private static async Task<Ok<List<MeetingDto>>> GetRejetedMeetings(ISender sender)
    {
        var meetings = await sender.Send(new GetRejetedMeetingsQuery());
        return TypedResults.Ok(meetings);
    }

    private static async Task<Ok<List<MeetingDto>>> GetNeededAnotherMeetings(ISender sender)
    {
        var meetings = await sender.Send(new GetNeededAnotherMeetingsQuery());
        return TypedResults.Ok(meetings);
    }

    private static async Task<Ok<List<MeetingDto>>> GetMeetingsByStatusDate(ISender sender, [AsParameters] GetMeetingsByStatusDateQuery query)
    {
        var meetings = await sender.Send(query);
        return TypedResults.Ok(meetings);
    }

    private static async Task<Ok<List<MeetingDto>>> GetMeetingByUserIdStatusDate(ISender sender, Guid userId, [AsParameters] GetMeetingByUserIdStatusDateQuery query)
    {
        var meetings = await sender.Send(query with { UserId = userId });
        return TypedResults.Ok(meetings);
    }
}
