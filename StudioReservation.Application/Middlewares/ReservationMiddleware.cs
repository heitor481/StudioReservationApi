using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;
using StudioReservation.Shared.Error;

namespace StudioReservation.Application.Middlewares
{
    public class ReservationMiddleware : IReservationMiddleware
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IStudioRepository studioRepository;
        private readonly IClientRepository clientRepository;
        private readonly IError error;

        public ReservationMiddleware(IReservationRepository reservationRepository,
        IStudioRepository studioRepository,
        IClientRepository clientRepository,
        IError error)
        {
            this.reservationRepository = reservationRepository;
            this.studioRepository = studioRepository;
            this.clientRepository = clientRepository;
            this.error = error;
        }

        //It has to change to use a collection of studio, rooms and schedule
        public async Task<Reservation> CreateReservation(DateTime dateOfTheReservation, Client clientReservation,
        ICollection<Studio> studios,
        ICollection<StudioRoom> studioRooms,
        ICollection<StudioRoomSchedule> studioRoomSchedules)
        {
            Client client = await this.clientRepository.FindClientById(clientReservation.Id);
            Reservation reservation = null;

            if (client == null) return null;

            reservation.Client = client;

            if (studios.Count == 0)
            {
                this.error.Message.Add("You must select at least one studio to make the reservation");
                return null;
            }

            else
            {
                foreach (var studioReserved in studios)
                {
                    Studio studio = await this.studioRepository.GetStudiosById(studioReserved.Id);

                    if (studio == null)
                    {
                        this.error.Message.Add("We haven't found the studio you selected");
                        return null;
                    }

                    //If I remember well, the entity framework will take care to generate the reservation and the Id automatically
                    ReservationStudio studioInReservation = new ReservationStudio
                    {
                        Studio = studio
                    };

                    reservation.AddStudioToReservation(studioInReservation);
                }
            }

            return null;
        }
    }
}