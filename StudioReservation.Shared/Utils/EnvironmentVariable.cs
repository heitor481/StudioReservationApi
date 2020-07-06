using System;

namespace StudioReservation.Shared.Utils
{
    public class EnvironmentVariable : IEnvironmentVariable
    {
        public string GetEnvironmentVariable(string environment)
        {
            return Environment.GetEnvironmentVariable(environment);
        }
    }
}
