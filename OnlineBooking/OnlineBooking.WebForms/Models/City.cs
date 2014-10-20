namespace OnlineBooking.WebForms.Models
{
    using System.Collections.Generic;

    public class City
    { 
        private ICollection<Place> places;

        public City()
        {
            this.Places = new List<Place>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public ICollection<Place> Places
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
