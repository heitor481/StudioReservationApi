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
using StudioReservation.Shared.Resources;
using System.Collections.Generic;

namespace StudioReservation.Application.Middlewares
{
    public class LoginMiddleware : ILoginMiddleware
    {
        private readonly ILoginRepository loginRepository;
        private readonly IEnvironmentVariable environmentVariable;
        private readonly ISharedResources sharedResources;
        private readonly IError error;

        public LoginMiddleware(ILoginRepository loginRepository,
            IEnvironmentVariable environmentVariable,
            IError error,
            ISharedResources sharedResources)
        {
            this.loginRepository = loginRepository;
            this.environmentVariable = environmentVariable;
            this.error = error;
            this.sharedResources = sharedResources;
        }

        public async Task<UserViewModel> Authenticate(string username, string password)
        {
            if (String.IsNullOrEmpty(username))
            {
                this.error.Message.Add(this.sharedResources.UsernameRequired);
            }

            if (String.IsNullOrEmpty(password))
            {
                this.error.Message.Add(this.sharedResources.PassWordRequired);
            }

            if (this.error.Message.Count > 0)
            {
                return null;
            }

            var result = await this.loginRepository.Authenticate(username, password);

            if (result == null)
            {
                this.error.Message.Add($"We could�t find any user with this {username} and {password}");
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

            userViewModel.Token = this.GenerateTokenForUser(userViewModel);

            return userViewModel;
        }

        private string GenerateTokenForUser(UserViewModel userViewModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.environmentVariable.GetEnvironmentVariable("SECRET_KEY"));
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userViewModel.Id.ToString())
                }),
                Claims = new Dictionary<string, object> { { "userviewmodel", userViewModel } },
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}