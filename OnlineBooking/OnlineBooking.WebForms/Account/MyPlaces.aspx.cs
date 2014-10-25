namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Web.UI;

    public partial class MyPlaces : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OdsPlaces.SelectParameters.Clear();
            OdsPlaces.SelectParameters.Add("currentUser", this.User.Identity.Name);
        }
    }
}