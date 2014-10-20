using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBooking.WebForms.Startup))]
namespace OnlineBooking.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
