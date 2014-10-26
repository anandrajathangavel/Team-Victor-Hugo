namespace OnlineBooking.WebForms.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineBooking.WebForms.BasePage;
    using Error_Handler_Control;
    using OnlineBooking.WebForms.Models;
    using Microsoft.AspNet.Identity;

    public partial class ManageUsers : BasePage
    {
        private const string ADMIN_ROLE = "admin";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UsersList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChangeRole")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = UsersList.Rows[index];
                TableCell selectedUserIdField = selectedRow.Cells[0];
                string id = selectedUserIdField.Text;

                var selectedUser = this.Data.Users.All().FirstOrDefault(c => c.Id == id);
                if(selectedUser.Id == User.Identity.GetUserId())
                {
                    ErrorSuccessNotifier.AddErrorMessage("You cannot change your own role!");
                    Response.Redirect("~/Admin/ManageUsers.aspx");
                }

                var userStore = new UserStore<ApplicationUser>(new OnlineBooking.WebForms.App_Data.OnlineBookingDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (userManager.IsInRole(selectedUser.Id, ADMIN_ROLE))
                {
                    userManager.RemoveFromRole(selectedUser.Id, ADMIN_ROLE);
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("User {0} in no longer {1}!", selectedUser.UserName, ADMIN_ROLE.ToUpper()));
                }
                else
                {
                    userManager.AddToRole(selectedUser.Id, ADMIN_ROLE);
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("User {0} is now {1}!", selectedUser.UserName, ADMIN_ROLE.ToUpper()));
                }

                Response.Redirect("~/Admin/ManageUsers.aspx");
            }
        }
    }
}