using OnlineBooking.WebForms.App_Data;
using OnlineBooking.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooking.WebForms.Account
{
    public partial class PlaceDetails : System.Web.UI.Page
    {
        private IOnlineBookingData data;
        public Place currentPlace;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
            int placeId = Convert.ToInt32(Request.Params["placeId"]);

            this.currentPlace = this.data.Places.All().FirstOrDefault(p => p.Id == placeId);
            if(currentPlace == null)
            {
                // Should be Not Found
                Response.Redirect("~/Default.aspx");
            }
            starsRepeater.DataSource = new Array[this.currentPlace.Stars];
            starsRepeater.DataBind();

            nightsList.DataSource = this.currentPlace.Nights;
            nightsList.DataBind();

        }

        protected void BookBtn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void AddNigthBtn_Command(object sender, CommandEventArgs e)
        {
            int placeId = Convert.ToInt32(e.CommandArgument);
            string queryString = string.Format("~/Account/AddNight?placeId={0}",placeId);
            Response.Redirect(queryString);
        }
    }
}