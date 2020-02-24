using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Application.Middlewares.Interfaces;

namespace StudioReservation.Api.Controllers
{
    [Route("studio")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IStudioMiddleware studioMiddleware;

        public StudioController(IStudioMiddleware studioMiddleware)
        {
            this.studioMiddleware = studioMiddleware;
        }

        [HttpGet]
        [Route("v1/api/getAllStudios")]
        public async Task<IActionResult> GetAllStudios() 
        {
            var result = await this.studioMiddleware.ListAllStudioAvaiable();
            return Ok(Task.FromResult(result));
        }
    }
}