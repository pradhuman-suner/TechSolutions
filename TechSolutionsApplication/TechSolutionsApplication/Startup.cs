using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechSolutionsApplication.Startup))]
namespace TechSolutionsApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
