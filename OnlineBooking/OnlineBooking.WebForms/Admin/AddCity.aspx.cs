namespace OnlineBooking.WebForms.Admin
{
    using System;
    using System.Linq;

    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;

    public partial class AddCity : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                var countries = this.Data.Counties.All().Select(c => c.Name).ToList();
                this.CountriesList.DataSource = countries;
                this.CountriesList.DataBind();
            }
        }

        protected void AddCity_Click(object sender, EventArgs e)
        {
            var selectedCountry = this.Data.Counties.All()
                .FirstOrDefault(c => c.Name == this.CountriesList.SelectedValue);

            City newCity = new City()
            {
                Name = this.CityName.Text,
                CountryId = selectedCountry.Id
            };

            this.Data.Cities.Add(newCity);
            this.Data.Counties.All().FirstOrDefault(c => c.Id == selectedCountry.Id).Cities.Add(newCity);
            this.Data.SaveChanges();

            Response.Redirect("~/Default.aspx");
        }
    }
}