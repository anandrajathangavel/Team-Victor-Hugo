namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;

    using OnlineBooking.WebForms.BasePage;
    using OnlineBooking.WebForms.Models;

    public partial class MyReservations : BasePage
    {

        public List<Reservation> CurrentReservation;

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = this.Data.Users.All().FirstOrDefault(u => u.Id == currentUserId);
            CurrentReservation = currentUser.Reservations.ToList();

            this.ReservationList.DataSource = CurrentReservation;
            this.ReservationList.DataBind();

        }
    }
}