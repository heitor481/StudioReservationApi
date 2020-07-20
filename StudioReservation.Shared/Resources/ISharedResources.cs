using System;
using System.Collections.Generic;
using System.Text;

namespace StudioReservation.Shared.Resources
{
    public interface ISharedResources
    {
        string FirstNameRequired { get; }
        string LastNameRequired { get; }

        string AgeHigherThanEighteen { get; }

        string EnterValidEmail { get; }

        string UsernameRequired { get; }

        string PassWordRequired { get; }
    }
}
