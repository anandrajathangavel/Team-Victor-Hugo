namespace OnlineBooking.WebForms.Services
{
    using System.Data;
    using System.Linq;
    using OnlineBooking.WebForms.App_Data;
    using OnlineBooking.WebForms.Models;

    public class CountryServices : Service
    {
        public CountryServices()
        {
        }

        public DataTable GetAll()
        {
            var countries = this.data.Counties.All();

            return this.IQueryableToDataTable(countries);
        }

        public void UpdateCountry(int id, string name)
        {
            var selectedCountry = this.data.Counties.All().FirstOrDefault(c => c.Id == id);
            selectedCountry.Name = name;

            this.data.SaveChanges();
        }

        public override DataTable IQueryableToDataTable(IQueryable countries)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");

            foreach (Country country in countries)
            {
                var row = dataTable.NewRow();

                row["ID"] = country.Id;
                row["Name"] = country.Name;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}