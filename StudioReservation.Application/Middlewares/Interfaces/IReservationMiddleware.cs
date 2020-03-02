using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.Application.Middlewares.Interfaces 
{
    public interface IReservationMiddleware 
    {
        Task<Reservation> CreateReservation(DateTime dateOfTheReservation, Client client, 
        ICollection<ReservationStudio> studioReservation,
        ICollection<ReservationStudioRoom> studioReservationRoom,
        ICollection<ReservationStudioRoomSchedule> studioReservationRoomSchedule);
    }
}