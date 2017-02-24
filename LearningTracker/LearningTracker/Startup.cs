using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningTracker.Startup))]
namespace LearningTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
