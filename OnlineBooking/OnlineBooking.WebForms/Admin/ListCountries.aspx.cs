namespace OnlineBooking.WebForms.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using OnlineBooking.WebForms.BasePage;
    using System.Data;
    using OnlineBooking.WebForms.Models;
    using Error_Handler_Control;

    public partial class ListCountries : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                var countries = this.Data.Counties.All();
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
                Session["CountriesList"] = dataTable;
                CountriesList.DataSource = dataTable;
                BindData();
            }

        }

        protected void CountriesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CountriesList.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();

        }

        protected void CountriesList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            CountriesList.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindData();

        }

        protected void CountriesList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            CountriesList.EditIndex = -1;
            //Bind data to the GridView control.
            BindData();

        }

        protected void CountriesList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["CountriesList"];
            //Update the values.
            GridViewRow row = CountriesList.Rows[e.RowIndex];

            string editedCountryName = ((TextBox)(row.Cells[2].Controls[0])).Text;
            int editedCountryId = int.Parse( (row.Cells[1].Text));

            dt.Rows[row.DataItemIndex]["Name"] = editedCountryName;

            var selectedCountry = this.Data.Counties.All().FirstOrDefault(c => c.Id == editedCountryId);
            selectedCountry.Name = editedCountryName;
            this.Data.SaveChanges();

            //Reset the edit index.
            CountriesList.EditIndex = -1;

            //Bind data to the GridView control.
            BindData();

            ErrorSuccessNotifier.AddSuccessMessage("Country Successfuly chanched!");

        }
        private void BindData()
        {
            CountriesList.DataSource = Session["CountriesList"];
            CountriesList.DataBind();
        }
    }
}