using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Map
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NumberOfPayment);
            builder.Property(p => p.PaymentDate).IsRequired();
            builder.Property(p => p.ExpiredDate);
            builder.Property(p => p.Total).IsRequired();
            builder.Property(p => p.TotalPaid).IsRequired();
            builder.Property(p => p.TotalPaid).IsRequired();
            builder.HasOne(p => p.Client);
            builder.HasOne(p => p.Reservation).WithOne(p => p.Payment).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
