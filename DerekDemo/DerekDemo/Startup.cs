using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DerekDemo.Startup))]
namespace DerekDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
