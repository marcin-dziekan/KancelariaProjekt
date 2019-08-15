using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Darek_kancelaria.Startup))]
namespace Darek_kancelaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
