using System.Security.Claims;
using Alkonof_Backend.Application.Modulers.Scheduling.Commands.CreateTimeTable;
using Alkonof_Backend.Application.Modulers.Scheduling.Commands.RemoveTimeTable;
using Alkonof_Backend.Application.Modulers.Scheduling.Commands.RestartTimeTable;
using Alkonof_Backend.Application.Modulers.Scheduling.Commands.UpdateTimeTable;
using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;
using Alkonof_Backend.Application.Modulers.Scheduling.Queries.GetTimeTablesByResponsibleId;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Scheduling;

public class Scheduling : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/", CreateTimeTable)
            .RequireAuthorization(); 

        group.MapPut("/{id:guid}", UpdateTimeTable)
            .RequireAuthorization();

        group.MapDelete("/{id:guid}", RemoveTimeTable)
            .RequireAuthorization();

        group.MapGet("/responsible/{responsibleId:guid}", GetTimeTablesByResponsibleId)
            .RequireAuthorization();
        group.MapGet("/{Id:guid}", GetTimeTablesById)
            .RequireAuthorization();

        group.MapPost("/restart", RestartTimeTable)
            .RequireAuthorization();
    }

    [EndpointSummary("Create a new timetable")]
    public static async Task<Ok<List<Guid>>> CreateTimeTable(ISender sender, HttpContext httpContext, [FromBody] List<TimeTableDto> dtos)
    {
        var requesterId = Guid.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var command = new CreateTimeTableCommand(dtos, requesterId);
        var result = await sender.Send(command);
        return TypedResults.Ok(result);
    }

    [EndpointSummary("Update a timetable entry")]
    public static async Task<IResult> UpdateTimeTable(ISender sender, HttpContext httpContext, Guid id, [FromBody] TimeTableDto dto)
    {
        if (id != dto.Id)
        {
            return TypedResults.BadRequest("ID in URL and body do not match.");
        }
        var requesterId = Guid.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var command = new UpdateTimeTableCommand(dto, requesterId);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Remove a timetable entry")]
    public static async Task<IResult> RemoveTimeTable(ISender sender, HttpContext httpContext, Guid id)
    {
        var requesterId = Guid.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var command = new RemoveTimeTableCommand(id, requesterId);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Get timetables by responsible ID")]
    public static async Task<Ok<List<TimeTableDto>>> GetTimeTablesByResponsibleId(ISender sender, Guid responsibleId)
    {
        var query = new GetTimeTablesByResponsibleIdQuery(responsibleId);
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }
    [EndpointSummary("Get timetables by ID")]
    public static async Task<Ok<List<TimeTableDto>>> GetTimeTablesById(ISender sender, Guid id)
    {
        var query = new GetTimeTablesByResponsibleIdQuery(id);
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }

    [EndpointSummary("Restart the weekly timetable (Enable all reservations)")]
    public static async Task<IResult> RestartTimeTable(ISender sender)
    {
        var command = new RestartTimeTableCommand();
        await sender.Send(command);
        return TypedResults.NoContent();
    }
}
