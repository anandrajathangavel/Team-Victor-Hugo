namespace OnlineBooking.WebForms.Data
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.Data.Migrations;

    public class OnlineBookingDbContext : IdentityDbContext<ApplicationUser>, IOnlineBookingContext
    {
        public OnlineBookingDbContext()
            : base("OnlineBookingConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineBookingDbContext, Configuration>());
        }
        
        public IDbSet<Country> Counties { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Place> Places { get; set; }

        public IDbSet<Service> Services { get; set; }

        public IDbSet<Night> Nights { get; set; }

        public IDbSet<Reservation> Reservations { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static OnlineBookingDbContext Create()
        {
            return new OnlineBookingDbContext();
        }
    }
}
