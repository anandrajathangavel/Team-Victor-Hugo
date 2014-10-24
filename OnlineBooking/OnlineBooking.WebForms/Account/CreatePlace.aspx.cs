namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Error_Handler_Control;
    using OnlineBooking.WebForms.Models;
    using OnlineBooking.WebForms.BasePage;
    using System.IO;

    public partial class CreatePlace : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // TODO: Repetitive cities validation
        protected void CreatePlace_Click(object sender, EventArgs e)
        {
            var selectedCity = this.Data.Cities.All()
                .FirstOrDefault(c => c.Name == this.Location.City);
            var currentUser = this.Data.Users.All()
                .FirstOrDefault(c => c.UserName == this.User.Identity.Name);
            var currentUserId = User.Identity.GetUserId();

            string placeNameText = this.PlaceName.Text;
            string imagePath;

            if (String.IsNullOrEmpty(placeNameText))
            {
                ErrorSuccessNotifier.AddErrorMessage("Place Name is Required!");
                Response.Redirect("CreatePlace.aspx");
            }

            if (String.IsNullOrEmpty(this.Location.Country) || String.IsNullOrEmpty(this.Location.City))
            {
                ErrorSuccessNotifier.AddErrorMessage("The selected location is invalid!");
                Response.Redirect("CreatePlace.aspx");
            }

            if (FileUploadControl.HasFile)
            {
                if (FileUploadControl.PostedFile.ContentType != "image/jpg" &&
                    FileUploadControl.PostedFile.ContentType != "image/jpeg" &&
                    FileUploadControl.PostedFile.ContentType != "image/png" )
                {
                    ErrorSuccessNotifier.AddErrorMessage("Invalid file type!");
                    Response.Redirect("CreatePlace.aspx");
                }
                if (FileUploadControl.PostedFile.ContentLength > 375000)
                {
                    ErrorSuccessNotifier.AddErrorMessage("File should be less than 3MB!");
                    Response.Redirect("CreatePlace.aspx");
                }

                string fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(FileUploadControl.FileName);
                
                string saveImagePath = Server.MapPath("~/Uploaded_Files/") + fileName;
                imagePath = "~/Uploaded_Files/" + fileName;
                FileUploadControl.SaveAs(saveImagePath);
            }
            else
            {
                imagePath = "../Uploaded_Files/Default-Image.png";
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
                ImagePath = imagePath,
                CityId = selectedCity.Id,
                Stars = starsCount,
                Capacity = int.Parse(this.Capacity.Text),
                Email = this.Email.Text,
                Phone = this.Phone.Text,
                AdministratorId = currentUserId
            };

            this.Data.Places.Add(newPlace);
            this.Data.SaveChanges();

            Response.Redirect("~/Account/MyPlaces.aspx");
        }
    }
}