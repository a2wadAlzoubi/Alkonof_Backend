using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CreateBooking;

public sealed record CreateBookingCommand(CreateBookingDto Dto) : IRequest<Guid>;
