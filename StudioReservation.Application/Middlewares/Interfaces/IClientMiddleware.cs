using System;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ValueObjects;

namespace StudioReservation.Application.Middlewares.Interfaces
{
    public interface IClientMiddleware
    {
        Task<Client> CreateClient(string firstName, string lastName, DateTime dateOfBirth, Document document, Email email, Address address);
    }
}