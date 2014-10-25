namespace OnlineBooking.WebForms.Admin
{
    using System;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;
    using Error_Handler_Control;

    public partial class AddCountry : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddCountryBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.CountryName.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("The name field is required!");
                Response.Redirect("AddCountry.aspx");
            }

            Country newCountry = new Country();
            newCountry.Name = this.CountryName.Text;

            this.Data.Counties.Add(newCountry);
            this.Data.SaveChanges();
            Response.Redirect("~/Default.aspx");
        }
    }
}