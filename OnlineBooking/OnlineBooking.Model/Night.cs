using System.Collections.Generic;

namespace OnlineBooking.Model
{
    public class Night
    {
        private ICollection<Place> places;

        public Night()
        {
            this.Places = new ICollection<Place>();
        }

        public int Id { get; set; }

        public RoomType Type { get; set; }

        public NightBasis Basis { get; set; }

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
