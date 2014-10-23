﻿namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;

    public partial class PlaceDetails : BasePage
    {
        private IOnlineBookingData data;
        public Place CurrentPlace;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
            int placeId = Convert.ToInt32(Request.Params["placeId"]);

            this.CurrentPlace = this.data.Places.All().FirstOrDefault(p => p.Id == placeId);
            if(CurrentPlace == null)
            {
                // Should be Not Found
                Response.Redirect("~/Default.aspx");
            }
            starsRepeater.DataSource = new Array[this.CurrentPlace.Stars];
            starsRepeater.DataBind();

            nightsList.DataSource = this.CurrentPlace.Nights;
            nightsList.DataBind();
        }

        protected void BookBtn_Command(object sender, CommandEventArgs e)
        {
            string queryString = string.Format("~/Account/BookForm?placeId={0}",
                this.CurrentPlace.Id);
            this.Response.Redirect(queryString);
        }

        protected void AddNigthBtn_Command(object sender, CommandEventArgs e)
        {
            string queryString = string.Format("~/Account/AddNight?placeId={0}",
                this.CurrentPlace.Id);
            this.Response.Redirect(queryString);
        }

    }
}