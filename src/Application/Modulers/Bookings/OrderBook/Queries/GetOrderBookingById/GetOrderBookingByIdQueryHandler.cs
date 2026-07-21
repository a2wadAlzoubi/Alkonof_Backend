using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Queries.GetOrderBookingById;

internal sealed class GetOrderBookingByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetOrderBookingByIdQuery, OrderBookingDto?>
{
    public async Task<OrderBookingDto?> Handle(GetOrderBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var orderBooking = await context.OrderBooking
            .AsNoTracking()
            .Include(ob => ob.Customer)
            .Include(ob => ob.Service)
            .Where(ob => ob.Id == request.OrderBookingId)
            .Select(ob => new OrderBookingDto
            {
                Id = ob.Id,
                CustomerId = ob.CustomerId,
                BookingTypeId = ob.ServiceId,
                CustomerName = ob.Customer!.Name,
                BookingTypeServiceName = ob.Service!.ServiceName
            })
            .FirstOrDefaultAsync(cancellationToken);

        return orderBooking;
    }
}
