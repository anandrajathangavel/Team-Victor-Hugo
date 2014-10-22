namespace OnlineBooking.WebForms.Services
{
    using System.Data;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;

    public class PlaceServices
    {
        private IOnlineBookingData data;

        public PlaceServices()
        {
            this.data = new OnlineBookingData(new OnlineBookingDbContext());
        }

        public DataTable GetAll(string country, string city, string starsStr)
        {
            int stars = 0;

            if (starsStr != null)
            {
                int.TryParse(starsStr, out stars);
            }
            
            var places = this.data.Places.All()
                .Where(p => 
                    (city != null ? p.City.Name == city : true) &&
                    (country != null ? p.City.Country.Name == country : true) &&
                    (starsStr != null ? p.Stars == stars : true)
                );

            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Location");
            dataTable.Columns.Add("Capacity");
            dataTable.Columns.Add("Stars");
            dataTable.Columns.Add("Phone");

            foreach (Place place in places)
            {
                var row = dataTable.NewRow();

                row["ID"] = place.Id;
                row["Name"] = place.Name;
                row["Location"] = string.Format("{0}, {1}", place.City.Name, place.City.Country.Name);
                row["Capacity"] = place.Capacity;
                row["Stars"] = place.Stars;
                row["Phone"] = place.Phone;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}