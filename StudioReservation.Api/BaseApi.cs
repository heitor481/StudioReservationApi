using Microsoft.AspNetCore.Mvc;
using StudioReservation.Shared.Entity;
using StudioReservation.Shared.Error;
using System.Net;

namespace StudioReservation.Api
{
    [ApiController]
    public class BaseApi : ControllerBase
    {
        private readonly Error error;
        public BaseApi(Error error)
        {
            this.error = error;
        }

        protected ApiResponse<object> CreateResponse(HttpStatusCode statusCode, object result)
        {
            if (statusCode == HttpStatusCode.BadRequest)
            {
                if (this.error.Message.Count > 0) 
                {
                    return new ApiResponse<object>
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Error = this.error
                    };
                }
            }
            else
            {
                return new ApiResponse<object>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = result
                };
            }

            return null;
        }
    }
}
