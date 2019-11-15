using System;
using System.Collections.Generic;
using System.Text;
using StudioReservation.Domain.ValueObjects;

namespace StudioReservation.Domain.Entities
{
    public class Studio : IIdentity
    {

        public int Id { get; set; }

        public string StudioName { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<StudioSchedule> StudioSchedule { get; set; }
    }
}
