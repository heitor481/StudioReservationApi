using System;
using System.Collections.Generic;
using System.Text;

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
