namespace OnlineBooking.WebForms
{
    using System;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;

    public partial class ListPlaces : System.Web.UI.Page
    {
        private IOnlineBookingData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());

            this.PlacesList.PageSize = 4;
        }
    }
}