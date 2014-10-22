namespace OnlineBooking.WebForms.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Reservation
    {
        private ICollection<Place> places;

        public Reservation()
        {
            this.Places = new List<Place>();
        }
        public int Id { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int NightsCount { get; set; }

        public bool Confirmed { get; set; }

        public virtual int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public virtual ICollection<Place> Places
        {
            get
            {
                return this.places;
            }
            set
            {
                this.places = value;
            }
        }
    }
}
