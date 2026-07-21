using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Commands.CreateOrderBooking;

internal sealed class CreateOrderBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateOrderBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderBookingCommand request, CancellationToken cancellationToken)
    {
        var orderBooking = OrderBooking.CreateOrderBooking(
            request.Dto.CustomerId,
            request.Dto.BookingTypeId
        );

        await context.OrderBooking.AddAsync(orderBooking, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return orderBooking.Id;
    }
}
