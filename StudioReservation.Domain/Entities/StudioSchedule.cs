using System;
using System.Collections.Generic;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class StudioSchedule : IIdentity
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public ICollection<Studio> Studio { get; set; }
    }
}
