
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class ReservationStudioMapping : IEntityTypeConfiguration<ReservationStudio>
    {
        public void Configure(EntityTypeBuilder<ReservationStudio> builder)
        {
            builder.ToTable("ReservationStudio");
            builder.HasKey(p => new {p.StudioId, p.ReservationId});
            builder.HasOne(p => p.Reservation).WithMany(p => p.ReservationStudio).HasForeignKey(p => p.ReservationId);
            builder.HasOne(p => p.Studio).WithMany(p => p.ReservationStudio).HasForeignKey(p => p.StudioId);
        }
    }
}
