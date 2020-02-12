using System;
using System.Collections.Generic;
using Flunt.Validations;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Reservation : IIdentity
    {
        public Reservation(DateTime dateOfTheReservation)
        {
            this.NumberOfReservation = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.DateOfTheReservation = dateOfTheReservation;
            this.Studio = new List<Studio>();
            this.StudioRoom = new List<StudioRoom>();
            this.StudioRoomSchedule = new List<StudioRoomSchedule>();
        }

        public string NumberOfReservation { get; set; }

        public DateTime DateOfTheReservation { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Studio> Studio { get; set; }

        public virtual ICollection<StudioRoom> StudioRoom { get; set; }

        public virtual ICollection<StudioRoomSchedule> StudioRoomSchedule { get; set; }

        public virtual Payment Payment { get; set; }

    }
}
