using System;
using Microsoft.EntityFrameworkCore;

namespace StudioReservation.Data
{
    public class StudioReservation : DbContext
    {
        //on the base part will go the connection string
        public StudioReservation() : base()
        {
        }
    }
}
