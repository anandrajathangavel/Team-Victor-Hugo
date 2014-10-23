namespace OnlineBooking.WebForms
{
    using System;
    using System.Linq;

    public partial class ListPlaces : BasePage.BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlacesList.PageSize = 4;
        }
    }
}