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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string queryString = string.Format("~/ListPlaces.aspx?Country={0}&City={1}&Stars={2}",
                this.LocationSelect.Country,
                this.LocationSelect.City,
                this.Stars.Text);
            this.Response.Redirect(queryString);
        }

        protected void DetailsBtn_Command(object sender, CommandEventArgs e)
        {
            int placeId = Convert.ToInt32(e.CommandArgument);

            string queryString = string.Format("~/Account/PlaceDetails.aspx?placeId={0}", placeId);
            Response.Redirect(queryString);
        }

    }
}