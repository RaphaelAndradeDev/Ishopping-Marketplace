using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ishopping.MVC.Startup))]
namespace Ishopping.MVC
{
    public partial class Startup
    {           
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }     
    }
}
