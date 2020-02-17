using System;
using System.Collections.Generic;
using Flunt.Validations;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class ReservationStudioRoom
    {
        public virtual Reservation Reservation { get; set; }
        public int ReservationId { get; set; }

        public virtual StudioRoom StudioRoom { get; set; }

        public int StudioRoomId { get; set; }
    }
}
