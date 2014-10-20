using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using OnlineBooking.Model;

namespace OnlineBooking.Model
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Place> adminOfPlaces;
        private ICollection<Notification> notifications;
        private ICollection<Reservation> reservations;

        public ApplicationUser()
            : base()
        {
            this.AdminOfPlaces = new ICollection<Place>();
            this.Notifications = new ICollection<Notification>();
            this.Reservations = new ICollection<Reservation>();
        }

        public bool Banned { get; set; }

        public ICollection<Reservation> Reservations
        {
            get
            {
                return this.reservations;
            }
            set
            {
                this.reservations = value;
            }
        }

        public ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }
            set
            {
                this.notifications = value;
            }
        }

        public ICollection<Place> AdminOfPlaces
        {
            get
            {
                return this.adminOfPlaces;
            }
            set
            {
                this.adminOfPlaces = value;
            }
        }


        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }


    }
}