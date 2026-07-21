using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Commands.RemoveOrderBooking;

internal sealed class RemoveOrderBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemoveOrderBookingCommand>
{
    public async Task Handle(RemoveOrderBookingCommand request, CancellationToken cancellationToken)
    {
        var orderBooking = await context.OrderBooking
            .FirstOrDefaultAsync(ob => ob.Id == request.OrderBookingId, cancellationToken);

        if (orderBooking is null)
        {
            throw new NotFoundException(nameof(OrderBooking), request.OrderBookingId.ToString());
        }

        context.OrderBooking.Remove(orderBooking);
        await context.SaveChangesAsync(cancellationToken);
    }
}
