using StudioReservation.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudioReservation.NewDomain.Entities
{
    public class StudioRoom : IIdentity
    {
        public int RoomNumber { get; set; }

        public bool? IsReserved { get; set; }

        public virtual Studio Studio { get; set; }

        public ICollection<ReservationStudioRoom> ReservationStudioRoom { get; set; }

        public virtual ICollection<StudioRoomSchedule> StudioRoomSchedule { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
