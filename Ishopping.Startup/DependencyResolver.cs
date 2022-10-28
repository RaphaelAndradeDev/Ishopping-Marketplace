using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Services;
using Ishopping.Infra.Data.Repositories;
using Microsoft.Practices.Unity;

namespace Ishopping.Startup
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //container.RegisterType<IAdminTemplateService, AdminTemplateService>(new HierarchicalLifetimeManager());
            //container.RegisterType<IAdminTemplateRepository, AdminTemplateRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            //container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}
