using System.Collections.Generic;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Studio : IIdentity
    {

        public string StudioName { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<StudioRoomSchedule> StudioRoomSchedule { get; set; }

        public virtual ICollection<StudioRoom> StudioRoom { get; set; }
    }
}
