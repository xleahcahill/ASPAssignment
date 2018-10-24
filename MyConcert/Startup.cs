using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyConcert.Startup))]
namespace MyConcert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
