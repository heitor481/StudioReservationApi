using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.Domain.Entities;

namespace StudioReservation.Data.Map
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NumberOfReservation);
            builder.Property(p => p.DateOfTheReservation);
            builder.HasOne(p => p.Client);
            builder.HasMany(p => p.Studio);
            builder.HasMany(p => p.StudioRoom);
            builder.HasMany(p => p.StudioRoomSchedule);
            builder.HasOne(p => p.Payment).WithOne(p => p.Reservation);
        }
    }
}
