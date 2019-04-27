using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PerfilUsuarios.Startup))]
namespace PerfilUsuarios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
