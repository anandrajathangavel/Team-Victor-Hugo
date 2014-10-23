namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;

    using OnlineBooking.WebForms.BasePage;
    using OnlineBooking.WebForms.Models;
    using Error_Handler_Control;

    public partial class ReservationsAdministration : BasePage
    {

        public List<Reservation> ReservationToApprove;

        protected void Page_Load(object sender, EventArgs e)
        {

            ReservationToApprove = this.Data.Reservations.All().Where(r => r.Confirmed == false).OrderBy(r => r.ArrivalDate).ToList();

            this.ReservationList.DataSource = ReservationToApprove;
            this.ReservationList.DataBind();

        }

        protected void ApproveReservation_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            var userId = User.Identity.GetUserId();
            //var currentUser = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);

            int reservationId = Convert.ToInt32(e.CommandArgument);
            var selectedReservation = this.Data.Reservations.All()
                        .FirstOrDefault(r => r.Id == reservationId && r.Place.AdministratorId == userId);
            selectedReservation.Confirmed = true;
            this.Data.SaveChanges();


            ErrorSuccessNotifier.AddSuccessMessage("Reservation Approved!");
            Response.Redirect("~/Account/ReservationsAdministration.aspx");
        }
    }
}