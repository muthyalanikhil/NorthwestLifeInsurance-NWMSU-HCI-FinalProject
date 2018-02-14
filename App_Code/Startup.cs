using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwestInsurance.Startup))]
namespace NorthwestInsurance
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
