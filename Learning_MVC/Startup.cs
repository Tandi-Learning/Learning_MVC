using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Learning_MVC.Startup))]
namespace Learning_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
