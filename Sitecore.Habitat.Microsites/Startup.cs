using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sitecore.Habitat.Microsites.Startup))]
namespace Sitecore.Habitat.Microsites
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
