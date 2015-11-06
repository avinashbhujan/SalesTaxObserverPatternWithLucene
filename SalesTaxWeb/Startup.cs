using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesTaxWeb.Startup))]
namespace SalesTaxWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
