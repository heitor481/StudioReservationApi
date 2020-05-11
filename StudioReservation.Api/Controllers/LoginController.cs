using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.Shared.Entity;
using StudioReservation.Shared.Error;

namespace StudioReservation.Api.Controllers
{
    [Route("authenticate")]
    public class LoginController : BaseApi
    {
        private readonly ILoginMiddleware loginMiddleware;

        public LoginController(ILoginMiddleware loginMiddleware, Error error) : base(error)
        {
            this.loginMiddleware = loginMiddleware;
        }

        [HttpPost]
        [Route("v1/api/login")]
        public async Task<ApiResponse<object>> Login(UserRequest userRequest) 
        {
            var userViewModel = await this.loginMiddleware.Authenticate(userRequest.UserName, userRequest.PassWord);
            if(userViewModel == null) return CreateResponse(HttpStatusCode.BadRequest, userViewModel);
            return CreateResponse(HttpStatusCode.OK, userViewModel);
        }
    }
}