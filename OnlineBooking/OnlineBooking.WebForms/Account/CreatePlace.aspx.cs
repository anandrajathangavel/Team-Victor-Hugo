namespace OnlineBooking.WebForms.Account

{
    using Error_Handler_Control;
    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CreatePlace : System.Web.UI.Page
    {
        private IOnlineBookingData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
        }

        // TODO: Repetitive cities validation
        protected void CreatePlace_Click(object sender, EventArgs e)
        {
            var selectedCity = this.data.Cities.All()
                .FirstOrDefault(c => c.Name == this.Location.City);
            var currentUser = this.data.Users.All()
                .FirstOrDefault(c => c.UserName == this.User.Identity.Name);

            string placeNameText = this.PlaceName.Text;
            
            if (placeNameText == null || placeNameText == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("Place Name is Required!");
                Response.Redirect("CreatePlace.aspx");
            }
            if (this.Stars.Text == null || this.Stars.Text == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("Stars Count is Required!");
                Response.Redirect("CreatePlace.aspx");
            }
            if (this.Capacity.Text == null || this.Capacity.Text == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("Capcity is Required!");
                Response.Redirect("CreatePlace.aspx");
            }

            int starsCount = int.Parse(this.Stars.Text);
            int capacity = int.Parse(this.Capacity.Text);

            if (starsCount < 1 || starsCount > 6)
            {
                ErrorSuccessNotifier.AddErrorMessage("Stars should be between 1  and 6!");
                Response.Redirect("CreatePlace.aspx");
            }
            if (capacity < 1 || capacity > 10000)
            {
                ErrorSuccessNotifier.AddErrorMessage("Capacity should be between 1  and 10 000!");
                Response.Redirect("CreatePlace.aspx");
            }

            Place newPlace = new Place()
            {
                Name = placeNameText,
                CityId = selectedCity.Id,
                Stars = starsCount,
                Capacity = int.Parse(this.Capacity.Text),
                Email = this.Email.Text,
                Phone = this.Phone.Text,
                Administrators = new List<ApplicationUser>() { currentUser }
            };

            this.data.Places.Add(newPlace);
            this.data.SaveChanges();
                
            Response.Redirect("~/Account/MyPlaces.aspx");
        }
    }
}