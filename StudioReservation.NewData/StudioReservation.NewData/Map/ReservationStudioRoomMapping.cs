
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class ReservationStudioRoomMapping : IEntityTypeConfiguration<ReservationStudioRoom>
    {
        public void Configure(EntityTypeBuilder<ReservationStudioRoom> builder)
        {
            builder.ToTable("ReservationStudioRoom");
            builder.HasKey(p => new {p.StudioRoomId, p.ReservationId});
            builder.HasOne(p => p.Reservation).WithMany(p => p.ReservationStudioRoom).HasForeignKey(p => p.ReservationId);
            builder.HasOne(p => p.StudioRoom).WithMany(p => p.ReservationStudioRoom).HasForeignKey(p => p.StudioRoomId);
        }
    }
}
