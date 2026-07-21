using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetConfirmedBooking;

internal sealed class GetConfirmedBookingQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetConfirmedBookingQuery, List<BookingDto>>
{
    public async Task<List<BookingDto>> Handle(GetConfirmedBookingQuery request, CancellationToken cancellationToken)
    {
        var bookings = await context.Booking
            .AsNoTracking()
            .Include(b => b.Customer)
            .Include(b => b.Responsible)
            .Where(b => b.Status == BookingStatus.Confirmed)
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
