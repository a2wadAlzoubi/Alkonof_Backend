using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignResponsibleAnswer;

public sealed record AssignResponsibleAnswerCommand(Guid BookingId, Guid ResponsibleId, Decision Decision) : IRequest;
