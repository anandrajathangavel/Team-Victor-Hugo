namespace OnlineBooking.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using OnlineBooking.Model;

    public interface IOnlineBookingContext
    {
        IDbSet<Country> Counties { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Place> Places { get; set; }

        IDbSet<Service> Services { get; set; }

        IDbSet<Night> Nights { get; set; }

        IDbSet<Reservation> Reservations { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }


        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
