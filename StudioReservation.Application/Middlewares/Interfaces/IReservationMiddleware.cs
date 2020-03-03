using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.Application.Middlewares.Interfaces 
{
    public interface IReservationMiddleware 
    {
        Task<Reservation> CreateReservation(DateTime dateOfTheReservation, Client clientReservation, 
        ICollection<Studio> studios,
        ICollection<StudioRoom> studioRooms,
        ICollection<StudioRoomSchedule> studioRoomSchedules);
    }
}