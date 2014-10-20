namespace OnlineBooking.Model
{
    using System;
    using System.Collections.Generic;

    public class Service
    {
        private ICollection<Place> places;

        public Service()
        {
            this.Places = new ICollection<Place>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

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
