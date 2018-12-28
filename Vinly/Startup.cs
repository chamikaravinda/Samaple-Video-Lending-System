using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vinly.Startup))]
namespace Vinly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
