using System;
using Flunt.Validations;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Client : IIdentity, IValidatable
    {
        public Client(string firstName, string lastName, DateTime dateBirth, Address address, Email email, Document document)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateBirth = dateBirth;
            this.Address = address;
            this.Email = email;
            this.Document = document;
        }
         
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public virtual Address Address { get; set; }

        public virtual Email Email { get; set; }

        public virtual Document Document { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                    .Requires()
                    .IsNullOrEmpty(this.FirstName, "First Name", "Your first name cannnot be empty")
                    .IsNullOrEmpty(this.LastName, "Last Name", "Your last name cannot be empty")
                    .IsNull(this.DateBirth, "Date Of Birth", "You have to insert you datebirth")
                    .IsGreaterOrEqualsThan(this.DateBirth, DateTime.Now, "Date Of Birth", "The date of birth cannot be greater or equals today")
                    .IsNull(this.Email, "Email", "Email cannot be null")
                    .IsNull(this.Document, "Document", "Document cannot be null")
                );
        }
    }
}
