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
    public partial class AddCountry : System.Web.UI.Page
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