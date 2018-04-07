using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigPrintWebApp.Startup))]
namespace BigPrintWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
