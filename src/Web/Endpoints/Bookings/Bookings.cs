using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignCustomerAnswer;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignResponsibleAnswer;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CancellBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.ConfirmBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CreateBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.DelayBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.ExpireBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.RemoveBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingById;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByUserId;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByUserIdStatusDate;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookings;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetConfirmedBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.CreateService;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.RemoveService;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.UpdateService;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServiceById;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServiceByName;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServices;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Domain.DateHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alkonof_Backend.Web.Endpoints.Bookings;

public class Bookings : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        var servicesGroup = group.MapGroup("/services");
        var bookingsGroup = group.MapGroup("/bookings");

        #region Services Endpoints
        servicesGroup.MapPost("/", CreateService).RequireAuthorization();
        servicesGroup.MapPut("/{id:guid}", UpdateService).RequireAuthorization();
        servicesGroup.MapDelete("/{id:guid}", RemoveService).RequireAuthorization();
        servicesGroup.MapGet("/{id:guid}", GetServiceById).RequireAuthorization();
        servicesGroup.MapGet("/type/{serviceType}", GetServiceByServiceType).RequireAuthorization();
        servicesGroup.MapGet("/", GetServices).RequireAuthorization();
        #endregion

        #region Booking Endpoints
        bookingsGroup.MapPost("/", CreateBooking).RequireAuthorization();
        bookingsGroup.MapPut("/{id:guid}", UpdateBooking).RequireAuthorization();
        bookingsGroup.MapDelete("/{id:guid}", RemoveBooking).RequireAuthorization();
        bookingsGroup.MapGet("/{id:guid}", GetBookingById).RequireAuthorization();
        bookingsGroup.MapGet("/customerdate/{customerId:guid}", GetBookingByUserIdDate).RequireAuthorization();
        bookingsGroup.MapGet("/customerstatusdate/{customerId:guid}", GetBookingByUserIdStatusDate).RequireAuthorization();
        bookingsGroup.MapGet("/date", GetBookingsByDate).RequireAuthorization();
        bookingsGroup.MapGet("/statusdate", GetBookingsByStatusDate).RequireAuthorization();
        #endregion

        #region Booking State Management Endpoints
        bookingsGroup.MapPost("/{bookingId:guid}/assign-customer-answer", AssignCustomerAnswer).RequireAuthorization();
        bookingsGroup.MapPost("/{bookingId:guid}/assign-responsible-answer", AssignResponsibleAnswer).RequireAuthorization();
        bookingsGroup.MapPost("/{bookingId:guid}/confirm", ConfirmBooking).RequireAuthorization();
        bookingsGroup.MapPost("/{bookingId:guid}/delay", DelayBooking).RequireAuthorization();
        bookingsGroup.MapPost("/{bookingId:guid}/cancel", CancellBooking).RequireAuthorization();
        bookingsGroup.MapPost("/{bookingId:guid}/expire", ExpireBooking).RequireAuthorization();
        #endregion

    }

    #region Services Handlers
    [EndpointSummary("Create a new service")]
    public static async Task<Results<Created<Guid>, BadRequest<string>>> CreateService(ISender sender, [FromBody] CreateServiceDto dto)
    {
        var command = new CreateServiceCommand(dto);
        var serviceId = await sender.Send(command);
        return TypedResults.Created($"/api/bookings/services/{serviceId}", serviceId);
    }

    [EndpointSummary("Update a service")]
    public static async Task<IResult> UpdateService(ISender sender,[FromBody] ServiceDto dto)
    {
        var command = new UpdateServiceCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Remove a service")]
    public static async Task<IResult> RemoveService(ISender sender, Guid id)
    {
        var command = new RemoveServiceCommand(id);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Get a service by ID")]
    public static async Task<Ok<ServiceDto>> GetServiceById(ISender sender, Guid id)
    {
        var query = new GetServiceByIdQuery(id);
        var service = await sender.Send(query);
        return TypedResults.Ok(service);
    }

    [EndpointSummary("Get services by service type")]
    public static async Task<Ok<List<ServiceDto>>> GetServiceByServiceType(ISender sender, string serviceType)
    {
        var query = new GetServiceByNameQuery(serviceType);
        var services = await sender.Send(query);
        return TypedResults.Ok(services);
    }

    [EndpointSummary("Get all services")]
    public static async Task<Ok<List<ServiceDto>>> GetServices(ISender sender)
    {
        var query = new GetServicesQuery();
        var services = await sender.Send(query);
        return TypedResults.Ok(services);
    }
    #endregion

    #region Booking Handlers
    [EndpointSummary("Create a new booking")]
    public static async Task<Results<Created<Guid>, BadRequest<string>>> CreateBooking(ISender sender, [FromBody] CreateBookingDto dto)
    {
        var command = new CreateBookingCommand(dto);
        var bookingId = await sender.Send(command);
        return TypedResults.Created($"/api/bookings/bookings/{bookingId}", bookingId);
    }

    [EndpointSummary("Update a booking")]
    public static async Task<IResult> UpdateBooking(ISender sender, [FromBody] BookingDto dto)
    {
        var command = new UpdateBookingCommand(dto);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Remove a booking")]
    public static async Task<IResult> RemoveBooking(ISender sender, Guid id)
    {
        var command = new RemoveBookingCommand(id);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Get a booking by ID")]
    public static async Task<Ok<BookingDto>> GetBookingById(ISender sender, Guid id)
    {
        var query = new GetBookingByIdQuery(id);
        var booking = await sender.Send(query);
        return TypedResults.Ok(booking);
    }

    [EndpointSummary("Get bookings by customer ID Date")]
    public static async Task<Ok<List<BookingDto>>> GetBookingByUserIdDate(ISender sender, Guid customerId , TimeRange range = TimeRange.None)
    {
        var query = new GetBookingByUserIdDateQuery(customerId , range);
        var bookings = await sender.Send(query);
        return TypedResults.Ok(bookings);
    }
    [EndpointSummary("Get bookings by customer ID Status , Date")]
    public static async Task<Ok<List<BookingDto>>> GetBookingByUserIdStatusDate(ISender sender, Guid customerId , BookingStatus status , TimeRange range = TimeRange.None)
    {
        var query = new GetBookingByUserIdStatusDateQuery(customerId , status , range);
        var bookings = await sender.Send(query);
        return TypedResults.Ok(bookings);
    }

    [EndpointSummary("Get all bookings by date")]
    public static async Task<Ok<List<BookingDto>>> GetBookingsByDate(ISender sender , TimeRange range)
    {
        var query = new GetBookingsQuery(range);
        var bookings = await sender.Send(query);
        return TypedResults.Ok(bookings);
    }
    [EndpointSummary("Get all bookings by status , date")]
    public static async Task<Ok<List<BookingDto>>> GetBookingsByStatusDate(ISender sender , BookingStatus status = BookingStatus.Confirmed , TimeRange range = TimeRange.None)
    {
        var query = new GetBookingsByStatusDateQuery(status , range);
        var bookings = await sender.Send(query);
        return TypedResults.Ok(bookings);
    }
    #endregion

    #region Booking State Management Handlers
    public record AssignAnswerRequest(Guid ActorId, Decision Decision);
    [EndpointSummary("Assign customer's answer to a booking")]
    public static async Task<IResult> AssignCustomerAnswer(ISender sender, Guid bookingId, [FromBody] AssignAnswerRequest request)
    {
        var command = new AssignCustomerAnswerCommand(bookingId, request.ActorId, request.Decision);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Assign responsible's answer to a booking")]
    public static async Task<IResult> AssignResponsibleAnswer(ISender sender, Guid bookingId, [FromBody] AssignAnswerRequest request)
    {
        var command = new AssignResponsibleAnswerCommand(bookingId, request.ActorId, request.Decision);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    public record ConfirmRequest(Guid CustomerId, Guid ResponsibleId);
    [EndpointSummary("Confirm a booking")]
    public static async Task<IResult> ConfirmBooking(ISender sender, Guid bookingId, [FromBody] ConfirmRequest request)
    {
        var command = new ConfirmBookingCommand(bookingId, request.CustomerId, request.ResponsibleId);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Delay a booking")]
    public static async Task<IResult> DelayBooking(ISender sender, Guid bookingId)
    {
        var command = new DelayBookingCommand(bookingId);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Cancel a booking")]
    public static async Task<IResult> CancellBooking(ISender sender, Guid bookingId)
    {
        var command = new CancellBookingCommand(bookingId);
        await sender.Send(command);
        return TypedResults.NoContent();
    }

    [EndpointSummary("Expire a booking")]
    public static async Task<IResult> ExpireBooking(ISender sender, Guid bookingId)
    {
        var command = new ExpireBookingCommand(bookingId);
        await sender.Send(command);
        return TypedResults.NoContent();
    }
    #endregion

}
