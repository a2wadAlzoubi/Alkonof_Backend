using Alkonof_Backend.Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alkonof_Backend.Infrastructure.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder
            .HasOne(b => b.Customer)
            .WithMany()
            .HasForeignKey(b => b.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.Responsibal)
            .WithMany()
            .HasForeignKey(b => b.ResponsibalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
