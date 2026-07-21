using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignCustomerAnswer;

public sealed record AssignCustomerAnswerCommand(Guid BookingId, Guid CustomerId, Decision Decision) : IRequest;
