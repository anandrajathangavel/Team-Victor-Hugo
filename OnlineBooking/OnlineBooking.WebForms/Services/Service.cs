namespace OnlineBooking.WebForms.Services
{
    using System.Data;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;

    public abstract class Service
    {
        protected readonly IOnlineBookingData data;

        public Service()
            : this(new OnlineBookingData(new OnlineBookingDbContext()))
        {
        }

        public Service(IOnlineBookingData data)
        {
            this.data = data;
        }

        public abstract DataTable IQueryableToDataTable(IQueryable dbData);
    }
}