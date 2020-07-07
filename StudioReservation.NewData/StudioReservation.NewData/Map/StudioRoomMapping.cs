using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class StudioRoomMapping : IEntityTypeConfiguration<StudioRoom>
    {
        public void Configure(EntityTypeBuilder<StudioRoom> builder)
        {
            builder.ToTable("StudioRoom");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.RoomNumber);
            builder.Property(p => p.IsReserved);
            builder.Property(p => p.IsDeleted);
            builder.HasOne(p => p.Studio).WithMany(p => p.StudioRoom).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.StudioRoomSchedule).WithOne(p => p.StudioRoom).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
