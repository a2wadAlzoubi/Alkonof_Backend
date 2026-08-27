using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Domain.DateHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByDayOfWeekAndResponsibleId;

internal sealed class GetBookingByDayOfWeekAndResponsibleIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetBookingByDayOfWeekAndResponsibleIdQuery, List<BookingDto>>
{
    public async Task<List<BookingDto>> Handle(GetBookingByDayOfWeekAndResponsibleIdQuery request, CancellationToken cancellationToken)
    {
        var timeRange = DateRangeHelper.GetWeekTimeRange(request.DayOfWeek);

        var bookings = await context.Booking
            .AsNoTracking()
            .Include(b => b.Customer)
            .Include(b => b.Responsible)
            .Where(b => b.ResponsibleId == request.ResponsibleId &&
                        b.ConfirmedAt >= timeRange.From &&
                        b.ConfirmedAt <= timeRange.To)
            .Select(b => new BookingDto
            {
                Id = b.Id,
                Title = b.Title,
                CustomerId = b.CustomerId,
                ResponsibleId = b.ResponsibleId,
                CustomerAnswer = b.CustomerAnswer,
                ConfirmedAt = b.ConfirmedAt,
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
