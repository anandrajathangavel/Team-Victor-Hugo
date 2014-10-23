namespace OnlineBooking.WebForms.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Place
    {
        private ICollection<Service> services;
        private ICollection<Night> nigths;
        private ICollection<Reservation> reservations;

        public Place()
        {
            this.Services = new List<Service>();
            this.Nights = new List<Night>();
            this.Reservations = new List<Reservation>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Stars { get; set; }

        public string ImagePath { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual int CityId { get; set; }

        public virtual City City { get; set; }

        public  string AdministratorId { get; set; }

        public virtual ApplicationUser Administrator { get; set; }
        
        public virtual ICollection<Service> Services
        {
            get
            {
                return this.services;
            }
            set
            {
                this.services = value;
            }
        }
        public virtual ICollection<Night> Nights
        {
            get
            {
                return this.nigths;
            }
            set
            {
                this.nigths = value;
            }
        }
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
    }
}
