using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.Shared.Entity;
using StudioReservation.Shared.Error;

namespace StudioReservation.Api.Controllers
{
    [Route("apî")]
    [Route("authenticate")]
    public class ClientController : BaseApi
    {
        private readonly IClientMiddleware clientMiddleware;

        public ClientController(Error error, IClientMiddleware clientMiddleware) : base(error)
        {
            this.clientMiddleware = clientMiddleware;
        }

        [HttpPost]
        [Route("/v1/create")]
        public async Task<ApiResponse<object>> Login(CreateClientViewModel createClientViewModel)
        {
            var response = await this.clientMiddleware.CreateClient(createClientViewModel);
            if (response == false) return CreateResponse(HttpStatusCode.BadRequest, response);
            return CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
