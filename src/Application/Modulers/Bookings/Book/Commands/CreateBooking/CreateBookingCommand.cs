using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CreateBooking;

[Authorize]
public sealed record CreateBookingCommand(CreateBookingDto Dto) : IRequest<Guid>;
