namespace OnlineBooking.Data
{
    using OnlineBooking.Data.Ropositories;
    using OnlineBooking.Model;

    public interface IOnlineBookingData
    {

        IGenericRepository<Country> Counties { get; }

        IGenericRepository<City> Cities { get; }

        IGenericRepository<Place> Places { get; }

        IGenericRepository<Service> Services { get; }

        IGenericRepository<Night> Nights { get; }

        IGenericRepository<Reservation> Reservations { get; }

        IGenericRepository<Notification> Notifications { get; }

        IGenericRepository<ApplicationUser> Users { get; }

        void SaveChanges();
    }
}
