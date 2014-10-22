namespace OnlineBooking.WebForms.Account
{
    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CreatePlace : System.Web.UI.Page
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

        protected void CreatePlace_Click(object sender, EventArgs e)
        {
            var selectedCity = this.data.Cities.All()
                .FirstOrDefault(c => c.Name == this.CitiesList.SelectedValue);
            var currentUser = this.data.Users.All()
                .FirstOrDefault(c => c.UserName == this.User.Identity.Name);

            Place newPlace = new Place()
            {
                Name = this.PlaceName.Text,
                CityId = selectedCity.Id,
                Stars = int.Parse(this.Stars.Text),
                Capacity = int.Parse(this.Capacity.Text),
                Email = this.Email.Text,
                Phone = this.Phone.Text,
                Administrators = new List<ApplicationUser>() { currentUser }
            };

            this.data.Places.Add(newPlace);
            this.data.SaveChanges();
        }

        private void UpdateCitiesList()
        {
            string selectedCountry = this.CountriesList.SelectedValue;
            var cities = this.data.Cities.All()
                .Where(c => c.Country.Name == selectedCountry)
                .Select(c => c.Name)
                .ToList();

            this.CitiesList.DataSource = cities;
            this.CitiesList.DataBind();
        }
    }
}