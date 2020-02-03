using Microsoft.EntityFrameworkCore;
using StudioReservation.Domain.Entities;

namespace StudioReservation.Data
{
    public class StudioReservationContext : DbContext
    {
        //on the base part will go the connection string
        public StudioReservationContext(DbContextOptions<StudioReservationContext> options) : base(options)
        {
            
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<StudioRoom> StudioRoom { get; set; }
        public DbSet<StudioRoomSchedule> StudioRoomSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
