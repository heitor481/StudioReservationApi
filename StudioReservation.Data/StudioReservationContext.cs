using System.Reflection;
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //this is necessary, because EF Core, doesn`t have the method "Conventions"
            //that we use to make the configuration of the tables
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                item.SetTableName(item.DisplayName().ToString());
            }
        }
    }
}
