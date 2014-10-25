namespace OnlineBooking.WebForms.App_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineBooking.WebForms.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineBookingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineBookingDbContext context)
        {

            if (!context.Users.Any())
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var administartor = new ApplicationUser() { UserName = "admin@admin.com", Email = "admin@admin.com" };
                userManager.Create(administartor, "123456");
            }

            if (!context.Roles.Any())
            {
                const string roleName = "admin";

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userIds = context.Users.Select(u => u.Id).ToList();

                roleManager.Create(new IdentityRole() { Name = roleName });

                foreach (var userId in userIds)
                {
                    userManager.AddToRole(userId, roleName);
                }
            }

            if (!context.Counties.Any())
            {
                var initialCountries = new List<Country>
                {
                    new Country { Name = "Bulgaria"},
                    new Country { Name = "UK"},
                    new Country { Name = "USA"}
                };

                initialCountries.ForEach(c => context.Counties.Add(c));
                context.SaveChanges();
            }
            if (!context.Cities.Any())
            {
                var initialCtities = new List<City>
                {
                    new City{Name = "Sofia", CountryId =1,},
                    new City{Name = "Plovidv", CountryId =1},
                    new City{Name = "Varna", CountryId =1,},

                    new City{Name = "London", CountryId =2,},
                    new City{Name = "Manchester", CountryId =2},
                    new City{Name = "Liverpool", CountryId =2,},

                    new City{Name = "Miami", CountryId =3,},
                    new City{Name = "New York", CountryId =3},
                    new City{Name = "Las Vegas", CountryId =3,}
                };

                initialCtities.ForEach(c => context.Cities.Add(c));
                context.SaveChanges();
            }
            if (!context.Places.Any())
            {
                string defaultImagePath = "../Uploaded_Files/Default-Image.png";
                var administrator = context.Users.FirstOrDefault(u => u.UserName == "admin@admin.com");
                var initialPlaces = new List<Place>
                {
                    new Place{ Name = "Hilton Sofia", Capacity = 4096, Stars =5, Phone= "0889111222", Email = "HiltonSofia@hilton.com", AdministratorId = administrator.Id, CityId = 1,ImagePath = defaultImagePath},
                    new Place{ Name = "Hotel Bulgaria", Capacity = 2048, Stars =4, Phone= "0873333222", Email = "bulgariaHotel@hotel.com", AdministratorId = administrator.Id, CityId = 1,ImagePath = defaultImagePath},
                    new Place{ Name = "Trimontium", Capacity = 2048, Stars =4, Phone= "0884552244", Email = "trimontium@hotel.com", AdministratorId = administrator.Id, CityId = 2,ImagePath = defaultImagePath},
                    new Place{ Name = "Cotinthia", Capacity = 8192, Stars =5, Phone= "+44 (0) 20 7930 8181", Email = "london@corinthia.com", AdministratorId = administrator.Id, CityId = 4,ImagePath = defaultImagePath},
                    new Place{ Name = "Downtown", Capacity = 5006, Stars =5, Phone= "(1)(646) 826-8600", Email = "downtown@manhattan.com", AdministratorId = administrator.Id, CityId = 8,ImagePath = defaultImagePath},
                    new Place{ Name = "Riviera Hotel & Casino", Capacity = 5006, Stars =5, Phone= "+1 702-734-5110", Email = "riviera@vegas.com", AdministratorId = administrator.Id, CityId = 9,ImagePath = defaultImagePath},
                };

                initialPlaces.ForEach(p => context.Places.Add(p));
                context.SaveChanges();
            }
            if (!context.Nights.Any())
            {
                var initialNights = new List<Night>
                {
                    new Night{Basis = NightBasis.Bed , Type = RoomType.Double , Price = 150},
                    new Night{Basis = NightBasis.All , Type = RoomType.Single , Price = 120},
                    new Night{Basis = NightBasis.BedAndBreakfast , Type = RoomType.FamilySuite , Price = 220},
                    new Night{Basis = NightBasis.Bed , Type = RoomType.JuniorSuite , Price = 200},
                    new Night{Basis = NightBasis.All , Type = RoomType.Single , Price = 163},
                    new Night{Basis = NightBasis.BedAndBreakfast , Type = RoomType.FamilySuite , Price = 530},
                    new Night{Basis = NightBasis.Bed , Type = RoomType.JuniorSuite , Price = 420},
                    new Night{Basis = NightBasis.All , Type = RoomType.JuniorSuite , Price = 316},
                    new Night{Basis = NightBasis.BedAndBreakfast , Type = RoomType.Double , Price = 256},
                    new Night{Basis = NightBasis.Bed , Type = RoomType.Single , Price = 200},
                    new Night{Basis = NightBasis.All , Type = RoomType.Double , Price = 436},
                    new Night{Basis = NightBasis.BedAndBreakfast , Type = RoomType.Double , Price = 75},
                    new Night{Basis = NightBasis.Bed , Type = RoomType.FamilySuite , Price = 1200},
                    new Night{Basis = NightBasis.All , Type = RoomType.JuniorSuite , Price = 235},
                    new Night{Basis = NightBasis.BedAndBreakfast , Type = RoomType.Double , Price = 99},
                };

                initialNights.ForEach(n => context.Nights.Add(n));
                context.SaveChanges();

                var random = new Random();
                foreach (var place in context.Places)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int randomNightId = random.Next(1, context.Nights.Count() + 1);
                        var randomNight = context.Nights.FirstOrDefault(n => n.Id == randomNightId);

                        randomNight.Places.Add(place);
                        place.Nights.Add(randomNight);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
