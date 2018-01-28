using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIMS.Startup))]
namespace CIMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
