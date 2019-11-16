using System;
using StudioReservation.Domain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class Payment : IIdentity
    {
        public Payment(DateTime paymentDate, DateTime expiredDate, decimal total, decimal totalPaid, Client client, Document clientDocument)
        {
            this.NumberOfPayment = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.PaymentDate = paymentDate;
            this.ExpiredDate = expiredDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Client = client;
            this.ClientDocument = clientDocument;
        }

        public string NumberOfPayment { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public virtual Client Client { get; set; }

        public virtual Document ClientDocument { get; set; }
    }
}
