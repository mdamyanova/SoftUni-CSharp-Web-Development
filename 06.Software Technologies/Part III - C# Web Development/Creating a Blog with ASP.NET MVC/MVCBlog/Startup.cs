using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBlog.Startup))]
namespace MVCBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
