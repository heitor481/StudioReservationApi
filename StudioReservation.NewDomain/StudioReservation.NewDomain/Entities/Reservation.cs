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
        }

        public string NumberOfReservation { get; set; }

        public DateTime DateOfTheReservation { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<ReservationStudio> ReservationStudio { get; set; }

        public ICollection<ReservationStudioRoom> ReservationStudioRoom { get; set; }

        public ICollection<ReservationStudioRoomSchedule> ReservationStudioRoomSchedule { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual int PaymentId { get; set; }

    }
}
