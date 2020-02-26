using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.NewData.Repository.Interfaces;
using System;

namespace StudioReservation.Application.Middlewares 
{
    public class LoginMiddleware : ILoginMiddleware
    {
        private readonly ILoginRepository loginRepository;

        public LoginMiddleware(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public async Task<UserViewModel> Authenticate(string username, string password)
        {
            if(username == "") {
                throw new Exception("Please, type your username");
            }

            if(password == "") {
                throw new Exception("Please, type your password");
            }

            var result = await this.loginRepository.Authenticate(username, password);

            if(result == null) {
                throw new Exception($"The user with{username} and {password} was not found");
            } 

            return new UserViewModel() 
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                UserName = result.Email.UserEmail,
                PassWord = result.Email.Password 
            };
        }
    }
}