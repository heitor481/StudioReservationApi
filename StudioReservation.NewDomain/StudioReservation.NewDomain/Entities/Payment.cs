using System;
using Flunt.Validations;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Payment : IIdentity, IValidatable
    {
        public Payment(DateTime paymentDate,
            DateTime expiredDate,
            decimal total,
            decimal totalPaid,
            Client client,
            Document clientDocument,
            Reservation reservation)
        {
            this.NumberOfPayment = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.PaymentDate = paymentDate;
            this.ExpiredDate = expiredDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Client = client;
            this.ClientDocument = clientDocument;
            this.Reservation = reservation;
        }

        public string NumberOfPayment { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public virtual Client Client { get; set; }

        public virtual Document ClientDocument { get; set; }

        public virtual Reservation Reservation { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                    .Requires()
                    .IsLowerThan(this.TotalPaid, this.Total, "Total Paid", "The amount paid has to be equal to the total")
                    .IsNull(this.Client, "Client", "The payment needs to have a client")
                    .IsNull(this.ClientDocument, "Client Document", "The payment needs the identification of the client")
                    .IsNull(this.Reservation, "Reservation", "The payment needs a reservation")
                );
        }
    }
}
