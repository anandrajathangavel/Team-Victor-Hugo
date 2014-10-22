namespace OnlineBooking.WebForms.Controls
{
    using System;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;

    public partial class LocationDropDown : System.Web.UI.UserControl
    {
        private IOnlineBookingData data;

        public string Country
        {
            get
            {
                if (this.CountriesList.SelectedValue != String.Empty)
                {
                    return this.CountriesList.SelectedValue;
                }

                return null;
            }
        }

        public string City
        {
            get
            {
                if (this.CitiesList.SelectedValue != String.Empty)
                {
                    return this.CitiesList.SelectedValue;
                }

                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());

            if (!this.IsPostBack)
            {
                var countries = this.data.Counties.All().Select(c => c.Name).ToList();
                this.CountriesList.DataSource = countries;
                this.CountriesList.DataBind();
                this.CountriesList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            }
        }

        protected void CountriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateCitiesList();
        }

        private void UpdateCitiesList()
        {
            string selectedCountry = this.CountriesList.SelectedValue;

            if (selectedCountry == String.Empty)
            {
                this.CitiesList.DataSource = new List<string>();
            }
            else
            {
                var cities = this.data.Counties.All()
                    .FirstOrDefault(c => c.Name == selectedCountry)
                    .Cities.Select(ci => ci.Name);

                this.CitiesList.DataSource = cities;
            }

            this.CitiesList.DataBind();
            this.CitiesList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        }
    }
}