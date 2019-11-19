using System;
using System.Collections.Generic;
using System.Linq;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class Reservation : IIdentity
    {
        public Reservation(DateTime dateOfTheReservation, Client client, Studio studio)
        {
            this.NumberOfReservation = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.DateOfTheReservation = dateOfTheReservation;
            this.Client = client;
            this.Studio = studio;
            this.StudioRoom = new List<StudioRoom>();
            this.StudioRoomSchedule = new List<StudioRoomSchedule>();

        }

        public string NumberOfReservation { get; set; }

        public DateTime DateOfTheReservation { get; set; }

        public virtual Client Client { get; set; }

        public virtual Studio Studio { get; set; }

        public virtual ICollection<StudioRoom> StudioRoom { get; set; }

        public virtual ICollection<StudioRoomSchedule> StudioRoomSchedule { get; set; }

    }
}
