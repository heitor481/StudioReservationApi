using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.Domain.Entities;
using System;

namespace StudioReservation.Data.Map
{
    public class StudioMapping : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.ToTable("Studio");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StudioName).IsRequired().HasMaxLength(100);
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(t => t.Country).IsRequired();
                a.Property(t => t.State).IsRequired();
                a.Property(t => t.City).IsRequired();
                a.Property(t => t.Neighborhood).IsRequired();
                a.Property(t => t.Street).IsRequired();
                a.Property(t => t.ZipCode).IsRequired();
            });

            builder.HasMany(p => p.StudioRoom).WithOne(p => p.Studio);
            builder.HasMany(p => p.StudioRoomSchedule).WithOne(p => p.Studio);
        }
    }
}
