using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HseqCentral.Startup))]
namespace HseqCentral
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
