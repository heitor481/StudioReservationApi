using System.Collections.Generic;
using StudioReservation.Domain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class Studio : IIdentity
    {

        public string StudioName { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<StudioSchedule> StudioSchedule { get; set; }
    }
}
