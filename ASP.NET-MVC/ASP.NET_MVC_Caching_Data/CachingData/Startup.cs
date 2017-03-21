using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CachingData.Startup))]
namespace CachingData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
