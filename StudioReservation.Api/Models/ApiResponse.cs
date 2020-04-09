using System.Net;

namespace StudioReservation.Api.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
