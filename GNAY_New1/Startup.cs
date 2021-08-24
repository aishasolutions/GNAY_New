using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GNAY_New1.Startup))]
namespace GNAY_New1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
