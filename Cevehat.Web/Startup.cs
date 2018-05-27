using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cevehat.Web.Startup))]
namespace Cevehat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
