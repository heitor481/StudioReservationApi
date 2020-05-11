using System.Net;
using StudioReservation.Shared.Error;

namespace StudioReservation.Shared.Entity
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public virtual Error.Error Error { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
