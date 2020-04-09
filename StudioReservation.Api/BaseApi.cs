using Microsoft.AspNetCore.Mvc;
using StudioReservation.Api.Models;
using System.Net;
using System.Threading.Tasks;

namespace StudioReservation.Api
{
    [ApiController]
    public class BaseApi : ControllerBase
    {
        protected ApiResponse<object> CreateResponse(HttpStatusCode statusCode, object result)
        {
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return new ApiResponse<object>
                {
                    Data = result,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            else
            {
                return new ApiResponse<object>
                {
                    Data = result,
                    StatusCode = HttpStatusCode.OK
                };
            }
        }
    }
}
