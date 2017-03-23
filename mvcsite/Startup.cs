using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcsite.Startup))]
namespace mvcsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
