using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FluentData.Web3.Startup))]
namespace FluentData.Web3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
