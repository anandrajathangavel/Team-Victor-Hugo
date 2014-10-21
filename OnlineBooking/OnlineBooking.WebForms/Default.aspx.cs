using OnlineBooking.WebForms.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooking.WebForms
{
    public partial class _Default : Page
    {
        private IOnlineBookingData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());

            var places = this.data.Places.All().ToList();

            this.DataListPlaces.DataSource = places;
            this.DataListPlaces.DataBind();
        }
    }
}