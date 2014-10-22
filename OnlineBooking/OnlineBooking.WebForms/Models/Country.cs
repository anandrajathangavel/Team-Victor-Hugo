namespace OnlineBooking.WebForms.Models
{
    using System;
using System.Collections.Generic;

    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.Cities = new List<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}
