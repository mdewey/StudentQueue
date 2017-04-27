using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentQueue.Startup))]
namespace StudentQueue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
