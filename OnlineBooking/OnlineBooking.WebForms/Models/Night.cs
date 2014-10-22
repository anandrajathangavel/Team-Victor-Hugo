namespace OnlineBooking.WebForms.Models
{
    using System.Collections.Generic;

    public class Night
    {
        private ICollection<Place> places;

        public Night()
        {
            this.Places = new List<Place>();
        }

        public int Id { get; set; }

        public RoomType Type { get; set; }

        public NightBasis Basis { get; set; }

        public decimal Price { get; set; }

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
