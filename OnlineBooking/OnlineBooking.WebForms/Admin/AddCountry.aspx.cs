namespace OnlineBooking.WebForms.Admin
{
    using System;
    using System.Linq;

    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;

    public partial class AddCountry : BasePage
    {
        private IOnlineBookingData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
        }

        protected void AddCountryBtn_Click(object sender, EventArgs e)
        {
            Country newCountry = new Country();
            newCountry.Name = this.CountryName.Text;

            this.data.Counties.Add(newCountry);
            this.data.SaveChanges();
            Response.Redirect("~/Default.aspx");
        }
    }
}