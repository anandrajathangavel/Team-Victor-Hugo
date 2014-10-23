namespace OnlineBooking.WebForms.App_Data
{
    using System;
    using System.Collections.Generic;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.App_Data.Repositories;
    
    public class OnlineBookingData: IOnlineBookingData
    {
        private IOnlineBookingContext context;

        private IDictionary<Type, object> repositories;

        public OnlineBookingData()
            :this(new OnlineBookingDbContext())
        {

        }

        public OnlineBookingData(IOnlineBookingContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IGenericRepository<City> Cities
        {
            get
            {
                return this.GetRepository<City>();
            }
        }

        public IGenericRepository<Service> Services
        {
            get
            {
                return this.GetRepository<Service>();
            }
        }

        public IGenericRepository<Night> Nights
        {
            get
            {
                return this.GetRepository<Night>();
            }
        }

        public IGenericRepository<Country> Counties
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IGenericRepository<Place> Places
        {
            get
            {
                return this.GetRepository<Place>();
            }
        }

        public IGenericRepository<Reservation> Reservations
        {
            get
            {
                return this.GetRepository<Reservation>();
            }
        }

        public IGenericRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
