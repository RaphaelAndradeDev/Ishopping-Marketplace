using Ishopping.Application;
using Ishopping.Application.Interface;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Services;
using Ishopping.Infra.Data.Repositories;
using Ishopping.Infra.Data.Repositories.Dapper;
using Ninject.Modules;

namespace Ishopping.Ninject.Modules
{
    public class ModuleForConfigUser : NinjectModule
    {        
        public override void Load()
        {
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IConfigUserDisplayAppService>().To<ConfigUserDisplayAppService>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IUserImageGalleryService>().To<UserImageGalleryService>();
            Bind<IUserRegisterProfileService>().To<UserRegisterProfileService>();
            Bind<IAdminViewDataService>().To<AdminViewDataService>();
            Bind<IConfigUserDisplayService>().To<ConfigUserDisplayService>();
            Bind<IConfigUserMaintenanceService>().To<ConfigUserMaintenanceService>();
            Bind<IUserFinancialService>().To<UserFinancialService>();

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IUserImageGalleryRepository>().To<UserImageGalleryRepository>();
            Bind<IUserRegisterProfileRepository>().To<UserRegisterProfileRepository>();
            Bind<IAdminViewDataRepository>().To<AdminViewDataRepository>();
            Bind<IConfigUserDisplayRepository>().To<ConfigUserDisplayRepository>();
            Bind<IConfigUserMaintenanceRepository>().To<ConfigUserMaintenanceRepository>();
            Bind<IUserFinancialRepository>().To<UserFinancialRepository>();

            // Dapper 
            Bind<IAdminViewDataDapperRepository>().To<AdminViewDataDapperRepository>();
            Bind<IConfigUserDisplayDapperRepository>().To<ConfigUserDisplayDapperRepository>();
            Bind<IConfigUserMaintenanceDapperRepository>().To<ConfigUserMaintenanceDapperRepository>();
            Bind<IUserFinancialDapperRepository>().To<UserFinancialDapperRepository>();
            Bind<IUserRegisterProfileDapperRepository>().To<UserRegisterProfileDapperRepository>();
            Bind<IUserImageGalleryDapperRepository>().To<UserImageGalleryDapperRepository>();
        }
    }
}