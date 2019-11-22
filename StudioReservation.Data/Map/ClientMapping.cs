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
            builder.HasKey(t => t.Id);
            builder.Property(p => p.FirstName).IsFixedLength().IsRequired();
            builder.Property(p => p.LastName).IsFixedLength().IsRequired();
            builder.Property(p => p.DateBirth).IsRequired();
        }
    }
}
