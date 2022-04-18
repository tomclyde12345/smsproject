using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(smsproject.Startup))]
namespace smsproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
