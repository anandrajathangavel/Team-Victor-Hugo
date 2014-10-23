using OnlineBooking.WebForms.App_Data;
using OnlineBooking.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Error_Handler_Control;

namespace OnlineBooking.WebForms.Account
{
    public partial class BookForm : System.Web.UI.Page
    {
        private IOnlineBookingData data;
        public Place CurrentPlace;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
            int placeId = Convert.ToInt32(Request.Params["placeId"]);

            this.CurrentPlace = this.data.Places.All().FirstOrDefault(p => p.Id == placeId);
            if (CurrentPlace == null)
            {
                // Should be Not Found
                Response.Redirect("~/Default.aspx");
            }

            if (!this.IsPostBack)
            {
                var nights = this.CurrentPlace.Nights;
                this.DataListNights.DataSource = nights;
                this.DataListNights.DataBind();
            }

        }

        protected void CreateReservation_Command1(object sender, CommandEventArgs e)
        {
            int nightId = Convert.ToInt32(e.CommandArgument);

            string currentUserId = User.Identity.GetUserId();
            var currentUser = this.data.Users.All().FirstOrDefault(u => u.Id == currentUserId);

            var selectedNight = this.CurrentPlace.Nights.FirstOrDefault(n => n.Id == nightId);
            var arrDate = DateTime.Parse(this.ArrivingDate.Value);
            var depDate = DateTime.Parse(this.DepartureDate.Value);

            if (arrDate < DateTime.Now)
            {
                ErrorSuccessNotifier.AddErrorMessage("Arriving date should be in the future!");
                Response.Redirect("~/Account/BookForm.aspx?placeId="+CurrentPlace.Id);
            }

            if (arrDate >= depDate)
            {
                ErrorSuccessNotifier.AddErrorMessage("Departure date should be after the arriving date!"); 
                Response.Redirect("~/Account/BookForm.aspx?placeId=" + CurrentPlace.Id);
            }

            var newReservation = new Reservation
            {
                ArrivalDate = arrDate,
                Confirmed = false,
                DepartureDate = depDate,
                UserId = currentUserId,
                PlaceId = CurrentPlace.Id
            };

            this.data.Reservations.Add(newReservation);
            this.CurrentPlace.Reservations.Add(newReservation);
            this.data.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Your reservation is now pending confirmation!");
            Response.Redirect("~/Default.aspx");
        }
    }
}