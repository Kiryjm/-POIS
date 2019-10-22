using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxTestApp.Startup))]
namespace AjaxTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
