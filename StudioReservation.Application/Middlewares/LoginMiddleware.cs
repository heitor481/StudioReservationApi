using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.NewData.Repository.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace StudioReservation.Application.Middlewares 
{
    public class LoginMiddleware : ILoginMiddleware
    {
        private readonly ILoginRepository loginRepository;
        private readonly IOptions<AppSettings> appSettings;

        public LoginMiddleware(ILoginRepository loginRepository, IOptions<AppSettings> appSettings)
        {
            this.loginRepository = loginRepository;
            this.appSettings = appSettings;
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

            //here you shouldn`t return an exception, but, a notification
            if(result == null) {
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
            var key = Encoding.ASCII.GetBytes(this.appSettings.Value.Secret);
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