using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooking.WebForms.Account
{
    public partial class MyPlaces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OdsPlaces.SelectParameters.Clear();
            OdsPlaces.SelectParameters.Add("currentUser", this.User.Identity.Name);
        }
    }
}