using System;
using Flunt.Notifications;
using Flunt.Validations;
using StudioReservation.Domain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class Client : IIdentity 
    {
        public Client(string firstName, string lastName, DateTime dateBirth, Address address, Email email, Document document)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateBirth = dateBirth;
            this.Address = address;
            this.Email = email;
            this.Document = document;

            AddNotifications(new Contract()
                    .IsNullOrEmpty(firstName, "First Name", "Your first name cannnot be empty")
                    .IsNullOrEmpty(lastName, "Last Name", "Your last name cannot be empty")
                    .IsNull(dateBirth, "Date Of Birth", "You have to insert you datebirth")
                );
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public Address Address { get; set; }

        public Email Email { get; set; }

        public Document Document { get; set; }

    }
}
