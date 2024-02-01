using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROYECTO_VERIS_MVC.Startup))]
namespace PROYECTO_VERIS_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
