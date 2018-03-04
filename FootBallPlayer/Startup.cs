using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootBallPlayer.Startup))]
namespace FootBallPlayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
