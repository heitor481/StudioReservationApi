using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.Application.Middlewares 
{
    public class ReservationMiddleware : IReservationMiddleware
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IStudioRepository studioRepository;

        public ReservationMiddleware(IReservationRepository reservationRepository, IStudioRepository studioRepository)
        {
            this.reservationRepository = reservationRepository;
            this.studioRepository = studioRepository;
        }

        public Task<Reservation> CreateReservation(DateTime dateOfTheReservation, Client client, 
        ICollection<ReservationStudio> studioReservation, 
        ICollection<ReservationStudioRoom> studioReservationRoom, 
        ICollection<ReservationStudioRoomSchedule> studioReservationRoomSchedule)
        {
            throw new NotImplementedException();
        }
    }
}