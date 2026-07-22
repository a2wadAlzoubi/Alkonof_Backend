using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Domain.DateHelper;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByUserId;

internal sealed class GetBookingByUserIdDateQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetBookingByUserIdDateQuery, List<BookingDto>>
{
    public async Task<List<BookingDto>> Handle(GetBookingByUserIdDateQuery request, CancellationToken cancellationToken)
    {
        var bookings = await context.Booking
            .AsNoTracking()
            .Include(b => b.Customer)
            .Include(b => b.Responsible)
            .Where(b => b.CustomerId == request.UserId || b.ResponsibleId == request.UserId)
            .Where(m => m.Created >= DateRangeHelper.GetFromDate(request.Range))
            .Select(b => new BookingDto
            {
                Id = b.Id,
                Title = b.Title,
                ExpiredAt = b.ExpiredAt,
                CustomerId = b.CustomerId,
                ResponsibleId = b.ResponsibleId,
                CustomerAnswer = b.CustomerAnswer,
                ResponsibleAnswer = b.ResponsibleAnswer,
                Status = b.Status,
                ContractId = b.ContractId,
                CustomerName = b.Customer!.Name,
                ResponsibleName = b.Responsible!.Name
            })
            .ToListAsync(cancellationToken);

        return bookings;
    }
}
