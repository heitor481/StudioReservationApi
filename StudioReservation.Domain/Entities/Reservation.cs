using System;
using System.Collections.Generic;
using Flunt.Validations;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Domain.Entities
{
    public class Reservation : IIdentity, IValidatable
    {
        public Reservation(DateTime dateOfTheReservation, Client client)
        {
            this.NumberOfReservation = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.DateOfTheReservation = dateOfTheReservation;
            this.Client = client;
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

        public void Validate()
        {
            AddNotifications(new Contract()
                    .Requires()
                    .IsNull(this.Client, "Client", "The client cannot be null")
                    .IsNull(this.Studio, "Studio", "Its necessary to select the studio for that operation")
                );
        }
    }
}
