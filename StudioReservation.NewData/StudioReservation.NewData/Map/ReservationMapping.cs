
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NumberOfReservation);
            builder.Property(p => p.DateOfTheReservation);
            builder.Property(p => p.IsCanceled);
            builder.HasOne(p => p.Client).WithMany(p => p.Reservation);
            builder.HasOne(p => p.Payment).WithOne(p => p.Reservation).HasForeignKey<Payment>(p => p.ReservationId); 
        }
    }
}
