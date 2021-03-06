﻿using System.Net;

namespace StudioReservation.Shared.Entity
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public virtual Error.IError Error { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
