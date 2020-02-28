using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Api.Controllers
{
    [ApiController]
    [Route("authenticate")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginMiddleware loginMiddleware;

        public LoginController(ILoginMiddleware loginMiddleware)
        {
            this.loginMiddleware = loginMiddleware;
        }

        [HttpPost]
        [Route("v1/api/login")]
        public async Task<IActionResult> Login(UserRequest userRequest) 
        {
            var userViewModel = await this.loginMiddleware.Authenticate(userRequest.UserName, userRequest.PassWord);
            return Ok(Task.FromResult(userViewModel));
        }
    }
}