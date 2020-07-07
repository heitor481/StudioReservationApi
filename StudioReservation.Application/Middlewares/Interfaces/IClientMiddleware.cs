using System;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Application.Middlewares.Interfaces
{
    public interface IClientMiddleware
    {
        Task<bool> CreateClient(CreateClientViewModel createClient);
    }
}