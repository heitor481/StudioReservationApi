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

        public string FirstNameRequired => this.localizer["FirstNameRequired"];

        public string LastNameRequired => this.localizer["LastNameRequired"];

        public string AgeHigherThanEighteen => this.localizer["AgeHigherThanEighteen"];

        public string EnterValidEmail => this.localizer["EnterValidEmail"];

        public string UsernameRequired => this.localizer["UsernameRequired"];

        public string PassWordRequired => this.localizer["PassWordRequired"];
    }
}
