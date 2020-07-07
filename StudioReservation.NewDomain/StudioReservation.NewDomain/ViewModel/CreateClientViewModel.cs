using StudioReservation.NewDomain.ValueObjects;
using System;

namespace StudioReservation.NewDomain.ViewModel
{
    public class CreateClientViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Document Document { get; set; }

        public Email Email { get; set; }

        public Address Address { get; set; }
    }
}
