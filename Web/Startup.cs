using Microsoft.Owin;
using Owin;
using Infrastructure;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ServiceLocator.RegisterAll();
        }
    }
}
