namespace OnlineBooking.WebForms.Services
{
    using System.Data;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;

    public abstract class Service
    {
        protected IOnlineBookingData Data {get;set;}

        public Service()
            : this(new OnlineBookingData())
        {
        }

        public Service(IOnlineBookingData data)
        {
            this.Data = data;
        }

        public abstract DataTable IQueryableToDataTable(IQueryable dbData);
    }
}