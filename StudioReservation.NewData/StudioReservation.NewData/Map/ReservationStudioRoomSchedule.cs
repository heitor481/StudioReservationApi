
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class ReservationStudioRoomScheduleMapping : IEntityTypeConfiguration<ReservationStudioRoomSchedule>
    {
        public void Configure(EntityTypeBuilder<ReservationStudioRoomSchedule> builder)
        {
            builder.ToTable("ReservationStudioRoomSchedule");
            builder.HasKey(p => new {p.StudioRoomScheduleId, p.ReservationId});
            builder.HasOne(p => p.Reservation).WithMany(p => p.ReservationStudioRoomSchedule).HasForeignKey(p => p.ReservationId);
            builder.HasOne(p => p.StudioRoomSchedule).WithMany(p => p.ReservationStudioRoomSchedule).HasForeignKey(p => p.StudioRoomScheduleId);
        }
    }
}
