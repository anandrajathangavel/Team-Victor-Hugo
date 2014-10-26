namespace OnlineBooking.WebForms.Services
{
    using System;
    using System.Data;
    using System.Linq;

    using OnlineBooking.WebForms.ViewModels;

    public class UsersService : Service
    {
        public DataTable GetAll()
        {
            var users = this.Data.Users.All().Select(u => new ListUserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Role =  u.Roles.Count > 0 ? "Admin" : "Regular"
            });

            return this.IQueryableToDataTable(users);
        }

        public override DataTable IQueryableToDataTable(IQueryable users)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Username");
            dataTable.Columns.Add("IsAdmin");

            foreach (ListUserViewModel user in users)
            {
                var row = dataTable.NewRow();

                row["Id"] = user.Id;
                row["Username"] = user.UserName;
                row["IsAdmin"] = user.Role;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}