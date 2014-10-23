using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace OnlineBooking.WebForms.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Notification> notifications;
        private ICollection<Reservation> reservations;

        public ApplicationUser()
            : base()
        {
            this.Notifications = new List<Notification>();
            this.Reservations = new List<Reservation>();
        }

        public bool Banned { get; set; }

        public virtual ICollection<Reservation> Reservations
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

        public virtual ICollection<Notification> Notifications
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