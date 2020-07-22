using System;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.Shared.Error;
using StudioReservation.Shared.Resources;

namespace StudioReservation.Application.Middlewares
{
    public class ClientMiddleware : IClientMiddleware
    {
        private readonly IClientRepository clientRepository;
        private readonly ISharedResources sharedResources;
        private readonly IError error;

        public ClientMiddleware(IClientRepository clientRepository, IError error, ISharedResources sharedResources)
        {
            this.clientRepository = clientRepository;
            this.error = error;
            this.sharedResources = sharedResources;
        }

        //start thinking about how you are going to refactor that to a better way
        public async Task<bool> CreateClient(CreateClientViewModel createClient)
        {
            if (String.IsNullOrEmpty(createClient.FirstName)) 
            {
                this.error.Message.Add(this.sharedResources.FirstNameRequired);
            }

            if (String.IsNullOrEmpty(createClient.LastName))
            {
                this.error.Message.Add(this.sharedResources.LastNameRequired);
            }

            if (createClient.Email == null) 
            {
                this.error.Message.Add("You need to have at least one valid email");
            }

            var ageOfClient = DateTime.Now.Year - createClient.DateOfBirth.Year;

            if (ageOfClient < 18) 
            {
                this.error.Message.Add(this.sharedResources.AgeHigherThanEighteen);
            }

            if (this.error.Message.Count > 0)
            {
                return false;
            }

            Client client = new Client(createClient.FirstName, createClient.LastName, createClient.DateOfBirth,
                createClient.Address, createClient.Email, createClient.Document);

            if (client.Document.DocumentIsValid()) 
            {
                this.error.Message.Add("The document that you added it's not a valid one. Please, type a valid one");
            }

            if (client.Email.IsValidEmail()) 
            {
                this.error.Message.Add(this.sharedResources.EnterValidEmail);
            }

            var result = await this.clientRepository.CreateClient(client);

            return result;
        }
    }
}