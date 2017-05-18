using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Khuluma_Server.Startup))]
namespace Khuluma_Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }


    }
}
