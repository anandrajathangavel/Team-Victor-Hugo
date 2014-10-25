namespace OnlineBooking.WebForms.Services
{
    using System.Data;
    using System.Linq;

    using OnlineBooking.WebForms.Models;

    public class PlaceServices : Service
    {
        public DataTable GetAll(string country, string city, string starsStr)
        {
            int stars = 0;

            if (starsStr != null)
            {
                int.TryParse(starsStr, out stars);
            }

            var places = this.Data.Places.All()
                .Where(p =>
                    (city != null ? p.City.Name == city : true) &&
                    (country != null ? p.City.Country.Name == country : true) &&
                    (starsStr != null ? p.Stars == stars : true)
                )
                .Select(p => new ListPlaceViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Stars = p.Stars,
                    Capacity = p.Capacity,
                    City = p.City.Name,
                    Country = p.City.Country.Name,
                    Phone = p.Phone
                });

            return this.IQueryableToDataTable(places);
        }

        public DataTable GetUserPlaces(string currentUser)
        {
            var places = this.Data.Places.All()
                .Where(p => p.Administrator.UserName == currentUser)
                .Select(p => new ListPlaceViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Stars = p.Stars,
                    Capacity = p.Capacity,
                    City = p.City.Name,
                    Country = p.City.Country.Name,
                    Phone = p.Phone
                });

            return this.IQueryableToDataTable(places);
        }

        public override DataTable IQueryableToDataTable(IQueryable places)
        {
                var dataTable = new DataTable();

                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Location");
                dataTable.Columns.Add("Capacity");
                dataTable.Columns.Add("Stars");
                dataTable.Columns.Add("Phone");

                foreach (ListPlaceViewModel place in places)
                {
                    var row = dataTable.NewRow();

                    row["ID"] = place.Id;
                    row["Name"] = place.Name;
                    row["Location"] = string.Format("{0}, {1}", place.City, place.Country);
                    row["Capacity"] = place.Capacity;
                    row["Stars"] = place.Stars;
                    row["Phone"] = place.Phone;

                    dataTable.Rows.Add(row);
                }

                return dataTable;
        }
    }
}