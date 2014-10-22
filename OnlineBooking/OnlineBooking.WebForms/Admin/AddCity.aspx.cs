using OnlineBooking.WebForms.App_Data;
using OnlineBooking.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooking.WebForms.Admin
{
    public partial class AddCity : System.Web.UI.Page
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
            }
        }

        protected void AddCity_Click(object sender, EventArgs e)
        {
            var selectedCountry = this.data.Counties.All()
                .FirstOrDefault(c => c.Name == this.CountriesList.SelectedValue);

            City newCity = new City()
            {
                Name = this.CityName.Text,
                CountryId = selectedCountry.Id
            };

            this.data.Cities.Add(newCity);
            this.data.SaveChanges();
        }
    }
}