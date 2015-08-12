using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Searcher.Startup))]
namespace Searcher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
