using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;

namespace StudioReservation.Shared.Entity
{
    public class IIdentity : Notifiable
    {
        public int Id { get; set; }
    }
}
