namespace OnlineBooking.WebForms
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using OnlineBooking.WebForms.App_Data;

    public partial class _Default : BasePage.BasePage
    {
        private const int PLACES_NUM = 6;
        private const int CACHE_EXP_MINUTES = 1;
        private IOnlineBookingData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
            
            if (this.Cache["FinestPlaces"] == null)
            {
                var finestPlaces = this.data.Places.All()
                    .OrderByDescending(p => p.Stars)
                    .Take(PLACES_NUM)
                    .ToList();

                this.Cache.Insert("FinestPlaces", finestPlaces, null, DateTime.Now.AddMinutes(CACHE_EXP_MINUTES), TimeSpan.Zero);
            }

            this.DataListPlaces.DataSource = this.Cache["FinestPlaces"];
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