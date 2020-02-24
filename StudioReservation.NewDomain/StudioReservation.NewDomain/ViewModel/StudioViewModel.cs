using System.Collections.Generic;
using StudioReservation.NewDomain.ValueObjects;

namespace StudioReservation.NewDomain.ViewModel 
{
    public class StudioViewModel 
    {
        public string StudioName { get; set; }

        public int Id { get; set; }

        public Address Address { get; set; }
    }   

}