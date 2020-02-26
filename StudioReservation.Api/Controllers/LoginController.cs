using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Application.Middlewares.Interfaces;

namespace StudioReservation.Api.Controllers
{
    [Route("authenticate")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginMiddleware loginMiddleware;

        public LoginController(ILoginMiddleware loginMiddleware)
        {
            this.loginMiddleware = loginMiddleware;
        }

        [HttpPost]
        [Route("v1/api/login")]
        public async Task<IActionResult> GetAllStudios([FromBody]string username, [FromBody]string password) 
        {
            var result = await this.loginMiddleware.Authenticate(username, password);
            return Ok(Task.FromResult(result));
        }
    }
}