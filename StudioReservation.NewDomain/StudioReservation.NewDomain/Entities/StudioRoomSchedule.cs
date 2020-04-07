using System;
using System.Collections.Generic;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class StudioRoomSchedule : IIdentity
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public virtual Studio Studio { get; set; }

        public virtual StudioRoom StudioRoom { get; set; }

        public ICollection<ReservationStudioRoomSchedule> ReservationStudioRoomSchedule { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
