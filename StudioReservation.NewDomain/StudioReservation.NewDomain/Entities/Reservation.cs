using System;
using System.Collections.Generic;
using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class Reservation : IIdentity
    {
        private Reservation(DateTime dateOfTheReservation)
        {
            this.NumberOfReservation = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.DateOfTheReservation = dateOfTheReservation;
        }

        public Reservation(DateTime dateOfTheReservation, Client client)
        {
            this.NumberOfReservation = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            this.DateOfTheReservation = dateOfTheReservation;
            this.ReservationStudio = new List<ReservationStudio>();
            this.ReservationStudioRoom = new List<ReservationStudioRoom>();
            this.ReservationStudioRoomSchedule = new List<ReservationStudioRoomSchedule>();
        }

        public string NumberOfReservation { get; set; }

        public DateTime DateOfTheReservation { get; set; }

        public virtual Client Client { get; set; }

        public bool? IsCanceled { get; set; }

        public virtual ICollection<ReservationStudio> ReservationStudio { get; set; }

        public ICollection<ReservationStudioRoom> ReservationStudioRoom { get; set; }

        public ICollection<ReservationStudioRoomSchedule> ReservationStudioRoomSchedule { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual int PaymentId { get; set; }

        
        public void AddStudioToReservation(ReservationStudio reservationStudio) 
        {
            if(reservationStudio != null) 
            {
                this.ReservationStudio.Add(reservationStudio);
            }
        }

        public void AddStudioRoomToReservation(ReservationStudioRoom reservationStudioRoom) 
        {
            if(reservationStudioRoom != null) 
            {
                this.ReservationStudioRoom.Add(reservationStudioRoom);
            }
        }

        public void AddStudioRoomScheduleToReservation(ReservationStudioRoomSchedule reservationStudioRoomSchedule) 
        {
            if(reservationStudioRoomSchedule != null) 
            {
                this.ReservationStudioRoomSchedule.Add(reservationStudioRoomSchedule);
            }
        }
    }
}
