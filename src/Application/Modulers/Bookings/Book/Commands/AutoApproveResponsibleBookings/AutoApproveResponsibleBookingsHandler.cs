using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignResponsibleAnswer;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AutoApproveResponsibleBookings;

internal sealed class AutoApproveResponsibleBookingsHandler(
    IApplicationDbContext context,
    ISender sender)
    : IRequestHandler<AutoApproveResponsibleBookingsCommand>
{
    public async Task Handle(
        AutoApproveResponsibleBookingsCommand request,
        CancellationToken cancellationToken)
    {
        var threshold = DateTimeOffset.UtcNow.AddMinutes(-2);

        var bookings = await context.Booking
            .Where(x =>
                x.Status == BookingStatus.InReviewResponsible &&
                x.LastModified <= threshold)
            .Select(x => new
            {
                x.Id,
                x.ResponsibleId
            })
            .ToListAsync(cancellationToken);

        foreach (var booking in bookings)
        {
            await sender.Send(
                new AssignResponsibleAnswerCommand(
                    booking.Id,
                    booking.ResponsibleId,
                    Decision.Approved),
                cancellationToken);
        }
    }
}
