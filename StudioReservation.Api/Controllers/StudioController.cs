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
    [Route("studio")]
    public class StudioController : BaseApi
    {
        private readonly IStudioMiddleware studioMiddleware;

        public StudioController(IStudioMiddleware studioMiddleware, IError error) : base(error)
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

        [HttpGet]
        [Route("v1/api/{studioId}")]
        public async Task<ApiResponse<object>> ListAllRoomsFromStudio(int studioId)
        {
            var result = await this.studioMiddleware.ListAllRoomsFromStudio(studioId);
            return CreateResponse(HttpStatusCode.OK, result);
        }
    }
}