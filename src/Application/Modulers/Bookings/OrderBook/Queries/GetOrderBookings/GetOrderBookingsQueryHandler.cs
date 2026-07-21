using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Queries.GetOrderBookings;

internal sealed class GetOrderBookingsQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetOrderBookingsQuery, List<OrderBookingDto>>
{
    public async Task<List<OrderBookingDto>> Handle(GetOrderBookingsQuery request, CancellationToken cancellationToken)
    {
        var orderBookings = await context.OrderBooking
            .AsNoTracking()
            .Include(ob => ob.Customer)
            .Include(ob => ob.Service)
            .Select(ob => new OrderBookingDto
            {
                Id = ob.Id,
                CustomerId = ob.CustomerId,
                BookingTypeId = ob.ServiceId,
                CustomerName = ob.Customer!.Name,
                BookingTypeServiceName = ob.Service!.ServiceName
            })
            .ToListAsync(cancellationToken);

        return orderBookings;
    }
}
