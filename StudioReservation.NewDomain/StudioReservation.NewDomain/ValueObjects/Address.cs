using System;
using System.Collections.Generic;
using System.Text;

namespace StudioReservation.NewDomain.ValueObjects
{
    public class Address
    {
        public Address()
        {

        }

        public Address(string country, string state, string city, string neighborhood, string street, string zipCode)
        {
            this.Country = country;
            this.State = state;
            this.City = city;
            this.Neighborhood = neighborhood;
            this.Street = street;
            this.ZipCode = zipCode;
        }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }
    }
}
