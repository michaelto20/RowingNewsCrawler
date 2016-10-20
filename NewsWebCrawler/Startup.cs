using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsWebCrawler.Startup))]
namespace NewsWebCrawler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
