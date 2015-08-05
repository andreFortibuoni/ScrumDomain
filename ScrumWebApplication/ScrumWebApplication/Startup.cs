using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScrumWebApplication.Startup))]
namespace ScrumWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
