using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBooking;

public sealed record UpdateBookingCommand(BookingDto Dto) : IRequest;
