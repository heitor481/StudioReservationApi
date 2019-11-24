using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.Domain.Entities;

namespace StudioReservation.Data.Map
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsFixedLength().IsRequired();
            builder.Property(p => p.LastName).IsFixedLength().IsRequired();
            builder.Property(p => p.DateBirth).IsRequired();
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(t => t.Country).IsRequired();
                a.Property(t => t.State).IsRequired();
                a.Property(t => t.City).IsRequired();
                a.Property(t => t.Neighborhood).IsRequired();
                a.Property(t => t.Street).IsRequired();
                a.Property(t => t.ZipCode).IsRequired();
            });

            builder.OwnsOne(p => p.Document, a =>
            {
                a.Property(t => t.ClientDocument).IsRequired();
                a.Property(t => t.DocumentType).IsRequired();
            });

            builder.OwnsOne(p => p.Email, a =>
            {
                a.Property(t => t.UserEmail).IsRequired().HasMaxLength(60);
                a.Property(t => t.Password).IsRequired().HasMaxLength(16);
            });
        }
    }
}
