using System.Collections.Generic;

namespace StudioReservation.Shared.Error
{
    public interface IError
    {
        public List<string> Message { get; set; }
    }
}
