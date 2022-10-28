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
    public class ModuleForContentSlider : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IContentSliderAppService>().To<ContentSliderAppService>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IUserImageGalleryService>().To<UserImageGalleryService>();
            Bind<IUserRegisterProfileService>().To<UserRegisterProfileService>();
            Bind<IAdminSliderConfigService>().To<AdminSliderConfigService>();
            Bind<IContentSliderService>().To<ContentSliderService>();

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IUserImageGalleryRepository>().To<UserImageGalleryRepository>();
            Bind<IUserRegisterProfileRepository>().To<UserRegisterProfileRepository>();
            Bind<IAdminSliderConfigRepository>().To<AdminSliderConfigRepository>();
            Bind<IContentSliderRepository>().To<ContentSliderRepository>();

            // Dapper 
            Bind<IUserRegisterProfileDapperRepository>().To<UserRegisterProfileDapperRepository>();
            Bind<IContentSliderDapperRepository>().To<ContentSliderDapperRepository>();
        }
    }
}