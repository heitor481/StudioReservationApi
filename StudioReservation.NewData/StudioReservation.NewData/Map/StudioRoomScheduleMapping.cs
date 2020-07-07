using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class StudioRoomScheduleMapping : IEntityTypeConfiguration<StudioRoomSchedule>
    {
        public void Configure(EntityTypeBuilder<StudioRoomSchedule> builder)
        {
            builder.ToTable("StudioRoomSchedule");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StartTime);
            builder.Property(p => p.EndTime);
            builder.Property(p => p.Duration);
            builder.Property(p => p.DayOfWeek);
            builder.Property(p => p.IsDeleted);
            builder.HasOne(p => p.Studio).WithMany(p => p.StudioRoomSchedule);
            builder.HasOne(p => p.StudioRoom).WithMany(p => p.StudioRoomSchedule);
        }
    }
}
