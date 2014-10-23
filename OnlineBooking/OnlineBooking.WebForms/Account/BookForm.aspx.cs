namespace OnlineBooking.WebForms.Account
{
    
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;

    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;
    using Error_Handler_Control;

    public partial class BookForm : BasePage
    {
        public Place CurrentPlace;

        protected void Page_Load(object sender, EventArgs e)
        {
            int placeId = Convert.ToInt32(Request.Params["placeId"]);

            this.CurrentPlace = this.Data.Places.All().FirstOrDefault(p => p.Id == placeId);
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
            
            var currentUser = this.Data.Users.All().FirstOrDefault(u => u.Id == currentUserId);
            var selectedNight = this.CurrentPlace.Nights.FirstOrDefault(n => n.Id == nightId);
            
            if (this.ArrivingDate.Value == string.Empty || this.DepartureDate.Value == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("Please enter arriving and departure dates!");
                Response.Redirect("~/Account/BookForm.aspx?placeId=" + CurrentPlace.Id);
            }

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
                //NightId = selectedNight.Id
            };

            this.Data.Reservations.Add(newReservation);
            this.CurrentPlace.Reservations.Add(newReservation);
            currentUser.Reservations.Add(newReservation);
            this.Data.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Your reservation is now pending confirmation!");
            Response.Redirect("~/Default.aspx");
        }
    }
}