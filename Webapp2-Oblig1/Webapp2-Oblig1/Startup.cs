using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webapp2_Oblig1.Startup))]
namespace Webapp2_Oblig1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
