using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsStore.Startup))]
namespace WebFormsStore
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
