using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudioReservation.Shared.Resources
{
    public class SharedResources : ISharedResources
    {
        private readonly IStringLocalizer<SharedResources> localizer;

        public SharedResources(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
        }

        public string FirstNameRequired => this.localizer["First name is required"];

        public string LastNameRequired => this.localizer["Last name is required"];

        public string AgeHigherThanEighteen => this.localizer["You must have 18 to use the app"];

        public string EnterValidEmail => this.localizer["The email typed is not valid"];

        public string UsernameRequired => this.localizer["Username is required"];

        public string PassWordRequired => this.localizer["Password is required"];
    }
}
