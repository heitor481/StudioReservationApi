using System;
using System.Collections.Generic;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Client : IIdentity
    {
        public Client(string firstName, string lastName, DateTime dateBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateBirth = dateBirth;
        }

         
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public virtual Address Address { get; set; }

        public virtual Email Email { get; set; }

        public virtual Document Document { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }

    }
}
