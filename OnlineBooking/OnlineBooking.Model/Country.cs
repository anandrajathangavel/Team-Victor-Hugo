namespace OnlineBooking.Model
{
    using System;
using System.Collections.Generic;

    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.Cities = new ICollection<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities
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
