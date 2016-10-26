using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebApiClient.Startup))]
namespace MVCWebApiClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
