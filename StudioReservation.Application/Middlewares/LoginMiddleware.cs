using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.NewData.Repository.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using StudioReservation.Shared.Error;
using StudioReservation.Shared.Utils;
using System.Collections.Generic;

namespace StudioReservation.Application.Middlewares
{
    public class LoginMiddleware : ILoginMiddleware
    {
        private readonly ILoginRepository loginRepository;
        private readonly IEnvironmentVariable environmentVariable;
        private readonly Error error;

        public LoginMiddleware(ILoginRepository loginRepository,
            IEnvironmentVariable environmentVariable,
            Error error)
        {
            this.loginRepository = loginRepository;
            this.environmentVariable = environmentVariable;
            this.error = error;
        }

        public async Task<UserViewModel> Authenticate(string username, string password)
        {
            if (username == "")
            {
                this.error.Message.Add("Please, type your username");
                return null;
            }

            if (password == "")
            {
                this.error.Message.Add("Please, type your password");
                return null;
            }

            var result = await this.loginRepository.Authenticate(username, password);

            if (result == null)
            {
                this.error.Message.Add($"We could´t find any user with this {username} and {password}");
                return null;
            }

            var userViewModel = new UserViewModel()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                UserName = result.Email.UserEmail,
                PassWord = result.Email.Password
            };

            userViewModel.Token = this.GenerateTokenForUser(userViewModel.Id);

            return userViewModel;
        }

        private string GenerateTokenForUser(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.environmentVariable.GetEnvironmentVariable("SECRET_KEY"));
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}