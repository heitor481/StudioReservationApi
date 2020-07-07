using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.Shared.Entity;
using StudioReservation.Shared.Error;

namespace StudioReservation.Api.Controllers
{
    [Authorize("Bearer")]
    [Route("apî")]
    public class StudioController : BaseApi
    {
        private readonly IStudioMiddleware studioMiddleware;

        public StudioController(IStudioMiddleware studioMiddleware, Error error) : base(error)
        {
            this.studioMiddleware = studioMiddleware;
        }

        [HttpGet]
        [Route("v1/studio/getAllStudios")]
        public async Task<ApiResponse<object>> GetAllStudios() 
        {
            var result = await this.studioMiddleware.ListAllStudioAvaiable();
            if (result == null) return CreateResponse(HttpStatusCode.BadRequest, result);
            return CreateResponse(HttpStatusCode.OK, result);
        }
    }
}