using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlowerLauage2018_8_17.Startup))]
namespace FlowerLauage2018_8_17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
