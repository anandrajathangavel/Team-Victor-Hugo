

namespace OnlineBooking.WebForms.BasePage
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using OnlineBooking.WebForms.App_Data;

    public class BasePage : Page
    {
        private IOnlineBookingData data;

        public BasePage()
        {
            this.Data = new OnlineBookingData();
        }

        protected IOnlineBookingData Data 
        { 
            get 
            {
                return this.data;
            } 
            private set 
            { 
                this.data = value;
            } 
        }
    }
}