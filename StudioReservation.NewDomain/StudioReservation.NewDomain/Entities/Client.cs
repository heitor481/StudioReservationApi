using System;
using System.Collections.Generic;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Client : IIdentity
    {

        /*
         * This is necessary because, EF core doesn't allow navigation properties on the public constructors
         * When generating migrations
         * That's why, it needs to create a private constructor for EF
         * And a public, for our own use
         */

        public Client(string firstName, string lastName, DateTime dateBirth, 
            Address address, 
            Email email,
            Document document)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateBirth = dateBirth;
            this.Email = email;
            this.Address = address;
            this.Document = document;
            this.IsActive = true;
        }

        private Client(string firstName, string lastName, DateTime dateBirth)
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

        public bool? IsActive { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }

    }
}
