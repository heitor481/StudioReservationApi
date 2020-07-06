using System;
using System.Collections.Generic;
using System.Text;

namespace StudioReservation.Shared.Utils
{
    public interface IEnvironmentVariable
    {
        string GetEnvironmentVariable(string environment);
    }
}
