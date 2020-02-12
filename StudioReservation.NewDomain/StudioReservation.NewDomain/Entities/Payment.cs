using System;
using Flunt.Validations;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Payment : IIdentity
    {
        public Payment(DateTime paymentDate,
            DateTime expiredDate,
            decimal total,
            decimal totalPaid)
        {
            this.NumberOfPayment = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.PaymentDate = paymentDate;
            this.ExpiredDate = expiredDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
        }

        public string NumberOfPayment { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public virtual Client Client { get; set; }

        public virtual Document ClientDocument { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
