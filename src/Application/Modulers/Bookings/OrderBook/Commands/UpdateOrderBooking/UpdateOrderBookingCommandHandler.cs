using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Commands.UpdateOrderBooking;

internal sealed class UpdateOrderBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateOrderBookingCommand>
{
    public async Task Handle(UpdateOrderBookingCommand request, CancellationToken cancellationToken)
    {
        var orderBooking = await context.OrderBooking
            .FirstOrDefaultAsync(ob => ob.Id == request.Dto.Id, cancellationToken);

        if (orderBooking is null)
        {
            throw new NotFoundException(nameof(OrderBooking), request.Dto.Id.ToString());
        }

        orderBooking.UpdateOrderBooking(
            request.Dto.CustomerId,
            request.Dto.BookingTypeId
        );

        await context.SaveChangesAsync(cancellationToken);
    }
}
