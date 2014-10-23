namespace OnlineBooking.WebForms.Account
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using OnlineBooking.WebForms.BasePage;
    using OnlineBooking.WebForms.Models;

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

        }
    }
}