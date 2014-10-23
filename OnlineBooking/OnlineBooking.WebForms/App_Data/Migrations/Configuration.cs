namespace OnlineBooking.WebForms.App_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OnlineBooking.WebForms.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineBookingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineBookingDbContext context)
        {
            var adminUser = context.Users.FirstOrDefault(u => u.UserName == "pesho@mail.com");

            if (adminUser != null)
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");

                if (adminRole == null)
                {
                    var newRole = new IdentityRole();
                    newRole.Name = "Admin";
                    context.Roles.Add(newRole);

                    adminUser.Roles.Add(new IdentityUserRole() { RoleId = newRole.Id, UserId = adminUser.Id });
                }
                else if (!adminUser.Roles.Any(u => u.UserId == adminUser.Id))
                {
                    adminUser.Roles.Add(new IdentityUserRole() { RoleId = adminRole.Id, UserId = adminUser.Id });
                }

                context.SaveChanges();
            }
        }
    }
}
