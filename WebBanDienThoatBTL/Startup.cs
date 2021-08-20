using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBanDienThoatBTL.Startup))]
namespace WebBanDienThoatBTL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
