using System;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ValueObjects;

namespace StudioReservation.Application.Middlewares
{
    public class ClientMiddleware : IClientMiddleware
    {
        public ClientMiddleware()
        {
            
        }

        public Task<Client> CreateClient(string firstName, string lastName, DateTime dateOfBirth, Document document, Email email, Address address)
        {
            throw new NotImplementedException();
        }
    }
}