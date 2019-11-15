using System;
namespace StudioReservation.Domain.Entities
{
    public class Reservation : IIdentity
    {
        public Reservation(DateTime dateOfTheReservation, Client client, Studio studio)
        {
            this.DateOfTheReservation = dateOfTheReservation;
            this.Client = client;
            this.Studio = studio;
        }

        public int Id { get; set; }

        public DateTime DateOfTheReservation { get; set; }

        public virtual Client Client { get; set; }

        public virtual Studio Studio { get; set; }

    }
}
