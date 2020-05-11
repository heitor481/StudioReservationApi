using Microsoft.AspNetCore.Mvc;
using StudioReservation.Shared.Entity;
using StudioReservation.Shared.Error;
using System.Net;

namespace StudioReservation.Api
{
    [ApiController]
    public class BaseApi : ControllerBase
    {
        protected ApiResponse<object> CreateResponse(HttpStatusCode statusCode, ApiResponse<object> result)
        {
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return new ApiResponse<object>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Error = result.Error
                };
            }
            else
            {
                return new ApiResponse<object>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = result.Data
                };
            }
        }
    }
}
