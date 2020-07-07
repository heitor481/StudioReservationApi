using System;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.Shared.Error;

namespace StudioReservation.Application.Middlewares
{
    public class ClientMiddleware : IClientMiddleware
    {
        private readonly IClientRepository clientRepository;
        private Error error;

        public ClientMiddleware(IClientRepository clientRepository, Error error)
        {
            this.clientRepository = clientRepository;
            this.error = error;
        }

        //start thinking about how you are going to refactor that to a better way
        public async Task<bool> CreateClient(CreateClientViewModel createClient)
        {
            if (String.IsNullOrEmpty(createClient.FirstName)) 
            {
                this.error.Message.Add("You must enter your first name");
            }

            if (String.IsNullOrEmpty(createClient.LastName))
            {
                this.error.Message.Add("You must enter your last name");
            }

            if (createClient.Email == null) 
            {
                this.error.Message.Add("You need to have at least one valid email");
            }

            var ageOfClient = DateTime.Now.Year - createClient.DateOfBirth.Year;

            if (ageOfClient > 18) 
            {
                this.error.Message.Add("You must have 18 to use the app");
            }

            if (this.error.Message.Count > 0)
            {
                return false;
            }

            Client client = new Client(createClient.FirstName, createClient.LastName, createClient.DateOfBirth,
                createClient.Address, createClient.Email, createClient.Document);

            var result = await this.clientRepository.CreateClient(client);

            return result;
        }
    }
}