using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingById;

internal sealed class GetBookingByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetBookingByIdQuery, BookingDto?>
{
    public async Task<BookingDto?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .AsNoTracking()
            .Include(b => b.Customer)
            .Include(b => b.Responsible)
            .Where(b => b.Id == request.BookingId)
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
            .FirstOrDefaultAsync(cancellationToken);

        return booking;
    }
}
