using System.Collections.Generic;

namespace StudioReservation.Shared.Error
{
    public class Error : IError
    {
        public Error()
        {
            this.Message = new List<string>();
        }

        public List<string> Message { get; set; }
    }
}
