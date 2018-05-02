using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobsISeaYouAt.Startup))]
namespace JobsISeaYouAt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
