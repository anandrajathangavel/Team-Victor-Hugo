namespace OnlineBooking.WebForms.Account
{
    using System;

    using OnlineBooking.WebForms.BasePage;

    public partial class MyPlaces : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OdsPlaces.SelectParameters.Clear();
            OdsPlaces.SelectParameters.Add("currentUser", this.User.Identity.Name);
        }
    }
}