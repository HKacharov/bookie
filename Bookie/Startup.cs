using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookie.Startup))]
namespace Bookie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
