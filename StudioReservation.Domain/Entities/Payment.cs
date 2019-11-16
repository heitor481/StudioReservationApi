using System;
using StudioReservation.Domain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class Payment : IIdentity
    {
        public Payment(DateTime paymentDate, DateTime expiredDate, Client client, Document document)
        {
            this.PaymentDate = paymentDate;
            this.ExpiredDate = expiredDate;
            this.Client = client;
            this.ClientDocument = document;
        }


        public DateTime PaymentDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Document ClientDocument { get; set; }
    }
}
