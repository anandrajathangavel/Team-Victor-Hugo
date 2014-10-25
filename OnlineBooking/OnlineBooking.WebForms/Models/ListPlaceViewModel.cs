using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBooking.WebForms.Models
{
    public class ListPlaceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }

        public int Capacity { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }
    }
}