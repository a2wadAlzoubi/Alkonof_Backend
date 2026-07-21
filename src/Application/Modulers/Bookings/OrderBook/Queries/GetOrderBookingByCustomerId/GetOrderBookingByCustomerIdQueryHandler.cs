using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Queries.GetOrderBookingByCustomerId;

internal sealed class GetOrderBookingByCustomerIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetOrderBookingByCustomerIdQuery, List<OrderBookingDto>>
{
    public async Task<List<OrderBookingDto>> Handle(GetOrderBookingByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var orderBookings = await context.OrderBooking
            .AsNoTracking()
            .Include(ob => ob.Customer)
            .Include(ob => ob.Service)
            .Where(ob => ob.CustomerId == request.CustomerId)
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
