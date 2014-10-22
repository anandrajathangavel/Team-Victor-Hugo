namespace OnlineBooking.WebForms.Controls
{
    using System;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;

    public partial class LocationDropDown : System.Web.UI.UserControl
    {
        private IOnlineBookingData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());

            if (!this.IsPostBack)
            {
                var countries = this.data.Counties.All().Select(c => c.Name).ToList();
                this.CountriesList.DataSource = countries;
                this.CountriesList.DataBind();

                this.UpdateCitiesList();
            }
        }

        protected void CountriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateCitiesList();
        }

        private void UpdateCitiesList()
        {
            string selectedCountry = this.CountriesList.SelectedValue;
            var cities = this.data.Counties.All()
                .FirstOrDefault(c => c.Name == selectedCountry)
                .Cities.Select(ci => ci.Name);

            this.CitiesList.DataSource = cities;
            this.CitiesList.DataBind();
        }
    }
}