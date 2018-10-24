using MyConcert.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyConcert.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingTicket> BookingTickets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowDetails> ShowDetails { get; set; }
        public DbSet<TicketDetails> DetailsOfTicket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}




