using System.Collections.Generic;

namespace StudioReservation.Shared.Error
{
    public class Error
    {
        public Error()
        {
            this.Message = new List<string>();
        }

        public List<string> Message { get; set; }
    }
}
