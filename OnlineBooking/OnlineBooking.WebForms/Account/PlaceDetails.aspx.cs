namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;

    public partial class PlaceDetails : BasePage
    {
        public Place CurrentPlace;

        protected void Page_Load(object sender, EventArgs e)
        {
            int placeId = Convert.ToInt32(Request.Params["placeId"]);

            this.CurrentPlace = this.Data.Places.All().FirstOrDefault(p => p.Id == placeId);
            if(CurrentPlace == null)
            {
                // Should be Not Found
                Response.Redirect("~/Default.aspx");
            }

            this.DetermineIfFieldsShouldBeShown(this.CurrentPlace);

            // Enables admin option if the current user is the owner of the place
            this.EnableAdminOptions(this.CurrentPlace.Administrator.UserName);

            // Sets page title
            this.Title = this.CurrentPlace.Name;

            starsRepeater.DataSource = new Array[this.CurrentPlace.Stars];
            starsRepeater.DataBind();

            this.NightsList.DataSource = this.CurrentPlace.Nights;
            this.NightsList.DataBind();

            this.PlaceImage.ImageUrl = this.CurrentPlace.ImagePath;
            this.PlaceImage.DataBind();
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

        private void EnableAdminOptions(string placeAdmin)
        {
            if (placeAdmin == this.User.Identity.Name)
            {
                this.AdminOptions.Visible = true;
            }
            else
            {
                this.AdminOptions.Visible = false;
            }
        }

        private void DetermineIfFieldsShouldBeShown(Place place)
        {
            if (String.IsNullOrEmpty(place.Email))
            {
                this.EmailContainer.Visible = false;
            }

            if (String.IsNullOrEmpty(place.Phone))
            {
                this.PhoneNumContainer.Visible = false;
            }
        }
    }
}