namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using OnlineBooking.WebForms.BasePage;
    using OnlineBooking.WebForms.Models;
    using Error_Handler_Control;

    public partial class AddNight : BasePage
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
                var roomTypes = new List<RoomType>();
                foreach (RoomType currentType in (RoomType[])Enum.GetValues(typeof(RoomType)))
                {
                    roomTypes.Add(currentType);
                }
                this.RoomTypeList.DataSource = roomTypes;
                this.RoomTypeList.DataBind();

                var roomBasises = new List<NightBasis>();
                foreach (NightBasis currentBasis in (NightBasis[])Enum.GetValues(typeof(NightBasis)))
                {
                    roomBasises.Add(currentBasis);
                }
                this.RoomBasisList.DataSource = roomBasises;
                this.RoomBasisList.DataBind();
            }

        }
        protected void AddNightBtn_Click(object sender, EventArgs e)
        {
            var roomType =  this.RoomTypeList.SelectedIndex;
            var roomBasis = this.RoomBasisList.SelectedIndex;
            var roomPrice = decimal.Parse(this.RoomPrice.Text);

            if (roomPrice < 0)
            {
                ErrorSuccessNotifier.AddErrorMessage("Price should be positive number!");
                Response.Redirect("~/Account/AddNight?placeId="+ this.CurrentPlace.Id);
            }
            var existingNight = this.Data.Nights.All().FirstOrDefault(n => n.Basis == (NightBasis)roomBasis && n.Type == (RoomType)roomType && n.Price == roomPrice);
            if(existingNight != null)
            {
                this.CurrentPlace.Nights.Add(existingNight);
                existingNight.Places.Add(CurrentPlace);
                this.Data.SaveChanges();
            }
            else
            {
                var newNight = new Night
                {
                    Basis = (NightBasis)roomBasis,
                    Type = (RoomType)roomType,
                    Price = roomPrice
                };
                newNight.Places.Add(CurrentPlace);
                this.CurrentPlace.Nights.Add(newNight);
                this.Data.SaveChanges();
            }

            ErrorSuccessNotifier.AddSuccessMessage("New night is added successfully!");
            Response.Redirect("~/Account/PlaceDetails?placeId=" + this.CurrentPlace.Id);


        }
    }
}