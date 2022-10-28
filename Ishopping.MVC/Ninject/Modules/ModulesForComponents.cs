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
    public class ModulesForComponents : NinjectModule
    {
        public override void Load()
        {
            // App Service
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>)); 
            Bind<IComponentBrandAppService>().To<ComponentBrandAppService>();
            Bind<IComponentClientAppService>().To<ComponentClientAppService>();
            Bind<IComponentMenuAppService>().To<ComponentMenuAppService>();   
            Bind<IComponentPortofolioAppService>().To<ComponentPortofolioAppService>();
            Bind<IComponentPostAppService>().To<ComponentPostAppService>();
            Bind<IComponentPresentationAppService>().To<ComponentPresentationAppService>();       
            Bind<IComponentProjectAppService>().To<ComponentProjectAppService>();            
            Bind<IComponentServiceAppService>().To<ComponentServiceAppService>();
            Bind<IComponentSimpleProductAppService>().To<ComponentSimpleProductAppService>(); 
            Bind<IComponentTeamAppService>().To<ComponentTeamAppService>();
            Bind<IComponentTeamSocialNetworkAppService>().To<ComponentTeamSocialNetworkAppService>();
            Bind<IComponentThumbnailAppService>().To<ComponentThumbnailAppService>();
            Bind<IUserImageGalleryAppService>().To<UserImageGalleryAppService>();

            //Option AppService
            Bind<IComponentBrandOptionAppService>().To<ComponentBrandOptionAppService>();
            Bind<IComponentClientOptionAppService>().To<ComponentClientOptionAppService>();  
            Bind<IComponentMenuOptionAppService>().To<ComponentMenuOptionAppService>();
            Bind<IComponentPortfolioOptionAppService>().To<ComponentPortfolioOptionAppService>();
            Bind<IComponentPostOptionAppService>().To<ComponentPostOptionAppService>();
            Bind<IComponentPresentationOptionAppService>().To<ComponentPresentationOptionAppService>();     
            Bind<IComponentProjectOptionAppService>().To<ComponentProjectOptionAppService>();         
            Bind<IComponentServiceOptionAppService>().To<ComponentServiceOptionAppService>();
            Bind<IComponentSimpleProductOptionAppService>().To<ComponentSimpleProductOptionAppService>();    
            Bind<IComponentTeamOptionAppService>().To<ComponentTeamOptionAppService>();


            // Service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IComponentBrandService>().To<ComponentBrandService>();
            Bind<IComponentClientService>().To<ComponentClientService>();
            Bind<IComponentMenuService>().To<ComponentMenuService>();
            Bind<IComponentPortofolioService>().To<ComponentPortofolioService>();
            Bind<IComponentPostService>().To<ComponentPostService>();
            Bind<IComponentPresentationService>().To<ComponentPresentationService>();
            Bind<IComponentProjectService>().To<ComponentProjectService>();            
            Bind<IComponentServiceService>().To<ComponentServiceService>();
            Bind<IComponentSimpleProductService>().To<ComponentSimpleProductService>(); 
            Bind<IComponentTeamService>().To<ComponentTeamService>();
            Bind<IComponentTeamSocialNetworkService>().To<ComponentTeamSocialNetworkService>();
            Bind<IComponentThumbnailService>().To<ComponentThumbnailService>();
            Bind<IUserImageGalleryService>().To<UserImageGalleryService>();

            // Option Service
            Bind<IComponentBrandOptionService>().To<ComponentBrandOptionService>();
            Bind<IComponentClientOptionService>().To<ComponentClientOptionService>();
            Bind<IComponentMenuOptionService>().To<ComponentMenuOptionService>();
            Bind<IComponentPortfolioOptionService>().To<ComponentPortfolioOptionService>();
            Bind<IComponentPostOptionService>().To<ComponentPostOptionService>();
            Bind<IComponentPresentationOptionService>().To<ComponentPresentationOptionService>();  
            Bind<IComponentProjectOptionService>().To<ComponentProjectOptionService>();           
            Bind<IComponentServiceOptionService>().To<ComponentServiceOptionService>();
            Bind<IComponentSimpleProductOptionService>().To<ComponentSimpleProductOptionService>();         
            Bind<IComponentTeamOptionService>().To<ComponentTeamOptionService>();


            // Repository
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));          
            Bind<IComponentBrandRepository>().To<ComponentBrandRepository>();
            Bind<IComponentClientRepository>().To<ComponentClientRepository>();
            Bind<IComponentMenuRepository>().To<ComponentMenuRepository>();
            Bind<IComponentPortofolioRepository>().To<ComponentPortofolioRepository>();
            Bind<IComponentPostRepository>().To<ComponentPostRepository>();
            Bind<IComponentPresentationRepository>().To<ComponentPresentationRepository>();        
            Bind<IComponentProjectRepository>().To<ComponentProjectRepository>();           
            Bind<IComponentServiceRepository>().To<ComponentServiceRepository>();
            Bind<IComponentSimpleProductRepository>().To<ComponentSimpleProductRepository>(); 
            Bind<IComponentTeamRepository>().To<ComponentTeamRepository>();
            Bind<IComponentTeamSocialNetworkRepository>().To<ComponentTeamSocialNetworkRepository>();
            Bind<IComponentThumbnailRepository>().To<ComponentThumbnailRepository>();
            Bind<IUserImageGalleryRepository>().To<UserImageGalleryRepository>();

            // Option Repository
            Bind<IComponentBrandOptionRepository>().To<ComponentBrandOptionRepository>();
            Bind<IComponentClientOptionRepository>().To<ComponentClientOptionRepository>(); 
            Bind<IComponentMenuOptionRepository>().To<ComponentMenuOptionRepository>();
            Bind<IComponentPortfolioOptionRepository>().To<ComponentPortfolioOptionRepository>();
            Bind<IComponentPostOptionRepository>().To<ComponentPostOptionRepository>();
            Bind<IComponentPresentationOptionRepository>().To<ComponentPresentationOptionRepository>();          
            Bind<IComponentProjectOptionRepository>().To<ComponentProjectOptionRepository>();        
            Bind<IComponentServiceOptionRepository>().To<ComponentServiceOptionRepository>();
            Bind<IComponentSimpleProductOptionRepository>().To<ComponentSimpleProductOptionRepository>();          
            Bind<IComponentTeamOptionRepository>().To<ComponentTeamOptionRepository>();

            // Dapper        
            Bind<IComponentBrandDapperRepository>().To<ComponentBrandDapperRepository>();
            Bind<IComponentClientDapperRepository>().To<ComponentClientDapperRepository>();
            Bind<IComponentMenuDapperRepository>().To<ComponentMenuDapperRepository>();
            Bind<IComponentPortofolioDapperRepository>().To<ComponentPortofolioDapperRepository>();                    
            Bind<IComponentPostDapperRepository>().To<ComponentPostDapperRepository>();
            Bind<IComponentPresentationDapperRepository>().To<ComponentPresentationDapperRepository>();          
            Bind<IComponentProjectDapperRepository>().To<ComponentProjectDapperRepository>();            
            Bind<IComponentServiceDapperRepository>().To<ComponentServiceDapperRepository>();
            Bind<IComponentSimpleProductDapperRepository>().To<ComponentSimpleProductDapperRepository>();         
            Bind<IComponentTeamDapperRepository>().To<ComponentTeamDapperRepository>();
            Bind<IComponentThumbnailDapperRepository>().To<ComponentThumbnailDapperRepository>();
            Bind<IUserImageGalleryDapperRepository>().To<UserImageGalleryDapperRepository>();

            // Admin
            Bind<IAdminSocialNetWorkRepository>().To<AdminSocialNetWorkRepository>();
        }
    }
}