using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AutoApproveResponsibleBookings;

public sealed record AutoApproveResponsibleBookingsCommand() : IRequest;
