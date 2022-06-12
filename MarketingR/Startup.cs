using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarketingR.Startup))]
namespace MarketingR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
