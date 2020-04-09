using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Api.Models;
using StudioReservation.Application.Middlewares.Interfaces;

namespace StudioReservation.Api.Controllers
{
    [Route("studio")]
    public class StudioController : BaseApi
    {
        private readonly IStudioMiddleware studioMiddleware;

        public StudioController(IStudioMiddleware studioMiddleware)
        {
            this.studioMiddleware = studioMiddleware;
        }

        [HttpGet]
        [Route("v1/api/getAllStudios")]
        public async Task<ApiResponse<object>> GetAllStudios() 
        {
            var result = await this.studioMiddleware.ListAllStudioAvaiable();
            if (result == null) return CreateResponse(HttpStatusCode.BadRequest, result);
            return CreateResponse(HttpStatusCode.OK, result);
        }
    }
}