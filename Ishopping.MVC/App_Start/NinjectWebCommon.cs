[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication3.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApplication3.App_Start.NinjectWebCommon), "Stop")]

namespace WebApplication3.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ishopping.Application.Interface;
    using Ishopping.Application;
    using Ishopping.Domain.Interfaces.Services;
    using Ishopping.Domain.Services;
    using Ishopping.Domain.Interfaces.Repositories;
    using Ishopping.Infra.Data.Repositories;
    using Ishopping.ViewModels.TemplateBasicPro;
    using Ishopping.ViewModels.TemplateProfessional;
    using Ishopping.Application.AppService;
    using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
    using Ishopping.Infra.Data.Repositories.Dapper;
    using Ishopping.MVC.ViewModels;
    using Ninject.Web.WebApi;
    using System.Web.Http;
    using Ishopping.Infra.Data.Repositories.EntityFramework;
    using Ishopping.Application.AppService.Ishopping;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {                            
            //Ishopping.Application
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));

            kernel.Bind<IAdminFinancialPlanAppService>().To<AdminFinancialPlanAppService>();
            kernel.Bind<IAdminImageGalleryAppService>().To<AdminImageGalleryAppService>();
            kernel.Bind<IAdminSliderAppService>().To<AdminSliderAppService>();
            kernel.Bind<IAdminSliderConfigAppService>().To<AdminSliderConfigAppService>();
            kernel.Bind<IAdminSocialNetWorkAppService>().To<AdminSocialNetWorkAppService>();
            kernel.Bind<IAdminTemplateAppService>().To<AdminTemplateAppService>();
            kernel.Bind<IAdminViewDataAppService>().To<AdminViewDataAppService>();
            kernel.Bind<IAdminViewItemAppService>().To<AdminViewItemAppService>();
            kernel.Bind<IComponentActivityAppService>().To<ComponentActivityAppService>();
            kernel.Bind<IComponentActivityOptionAppService>().To<ComponentActivityOptionAppService>();
            kernel.Bind<IComponentBrandAppService>().To<ComponentBrandAppService>();
            kernel.Bind<IComponentClientAppService>().To<ComponentClientAppService>();
            kernel.Bind<IComponentExtraLinkAppService>().To<ComponentExtraLinkAppService>();
            kernel.Bind<IComponentFaqAppService>().To<ComponentFaqAppService>();
            kernel.Bind<IComponentFeaturesAppService>().To<ComponentFeaturesAppService>();
            kernel.Bind<IComponentPanelAppService>().To<ComponentPanelAppService>();
            kernel.Bind<IComponentPortofolioAppService>().To<ComponentPortofolioAppService>();
            kernel.Bind<IComponentPostAppService>().To<ComponentPostAppService>();
            kernel.Bind<IComponentPresentationAppService>().To<ComponentPresentationAppService>();
            kernel.Bind<IComponentPricingAppService>().To<ComponentPricingAppService>();
            kernel.Bind<IComponentProjectAppService>().To<ComponentProjectAppService>();
            kernel.Bind<IComponentScopeAppService>().To<ComponentScopeAppService>();
            kernel.Bind<IComponentServiceAppService>().To<ComponentServiceAppService>();
            kernel.Bind<IComponentSimpleProductAppService>().To<ComponentSimpleProductAppService>();
            kernel.Bind<IComponentSkillAppService>().To<ComponentSkillAppService>();
            kernel.Bind<IComponentSocialNetworkAppService>().To<ComponentSocialNetworkAppService>();
            kernel.Bind<IComponentSummaryAppService>().To<ComponentSummaryAppService>();
            kernel.Bind<IComponentTeamAppService>().To<ComponentTeamAppService>();
            kernel.Bind<IComponentTeamSocialNetworkAppService>().To<ComponentTeamSocialNetworkAppService>();            
            kernel.Bind<IComponentMenuAppService>().To<ComponentMenuAppService>();
            kernel.Bind<IComponentThumbnailAppService>().To<ComponentThumbnailAppService>();
            kernel.Bind<IConfigUserAppearanceAppService>().To<ConfigUserAppearanceAppService>();
            kernel.Bind<IConfigUserDisplayAppService>().To<ConfigUserDisplayAppService>();
            kernel.Bind<IConfigUserMaintenanceAppService>().To<ConfigUserMaintenanceAppService>();
            kernel.Bind<IConfigUserStyleClassAppService>().To<ConfigUserStyleClassAppService>();
            kernel.Bind<IConfigUserStyleColorAppService>().To<ConfigUserStyleColorAppService>();
            kernel.Bind<IConfigUserViewItemAppService>().To<ConfigUserViewItemAppService>();
            kernel.Bind<IConfigUserViewAppService>().To<ConfigUserViewAppService>();
            kernel.Bind<IContentButtonAppService>().To<ContentButtonAppService>();
            kernel.Bind<IContentIconAppService>().To<ContentIconAppService>();
            kernel.Bind<IContentListAppService>().To<ContentListAppService>();
            kernel.Bind<IContentSliderAppService>().To<ContentSliderAppService>();
            kernel.Bind<IContentTextAppService>().To<ContentTextAppService>();
            kernel.Bind<IContentVideoAppService>().To<ContentVideoAppService>();
            kernel.Bind<IECommerceProductCategoryAppService>().To<ECommerceProductCategoryAppService>();
            kernel.Bind<IECommerceProductGroupAppService>().To<ECommerceProductGroupAppService>();
            kernel.Bind<IECommerceProductAppService>().To<ECommerceProductAppService>();
            kernel.Bind<IECommerceProductSoldAppService>().To<ECommerceProductSoldAppService>();
            kernel.Bind<IECommerceShoppingListAppService>().To<ECommerceShoppingListAppService>();
            kernel.Bind<IAppViewAppService>().To<AppViewAppService>();
            kernel.Bind<ISupportErrorAppService>().To<SupportErrorAppService>();
            kernel.Bind<ISupportInfoAppService>().To<SupportInfoAppService>();
            kernel.Bind<ISupportNotificationAppService>().To<SupportNotificationAppService>();
            kernel.Bind<ISupportTransactionAppService>().To<SupportTransactionAppService>();
            kernel.Bind<ISupportTransactionStatusAppService>().To<SupportTransactionStatusAppService>();
            kernel.Bind<IUserFinancialHistoryAppService>().To<UserFinancialHistoryAppService>();
            kernel.Bind<IUserFinancialAppService>().To<UserFinancialAppService>();
            kernel.Bind<IUserImageGalleryAppService>().To<UserImageGalleryAppService>();
            kernel.Bind<IUserMenuAppService>().To<UserMenuAppService>();
            kernel.Bind<IUserMenuViewItemAppService>().To<UserMenuViewItemAppService>();
            kernel.Bind<IUserMenuViewAppService>().To<UserMenuViewAppService>();
            kernel.Bind<IUserRegisterProfileAppService>().To<UserRegisterProfileAppService>();
            kernel.Bind<IUserRegisterStandardAppService>().To<UserRegisterStandardAppService>();
            kernel.Bind<IUserSerializeViewDataAppService>().To<UserSerializeViewDataAppService>();

            kernel.Bind<IComponentBrandOptionAppService>().To<ComponentBrandOptionAppService>();
            kernel.Bind<IComponentClientOptionAppService>().To<ComponentClientOptionAppService>();
            kernel.Bind<IComponentExtraLinkOptionAppService>().To<ComponentExtraLinkOptionAppService>();
            kernel.Bind<IComponentFaqOptionAppService>().To<ComponentFaqOptionAppService>();
            kernel.Bind<IComponentFeaturesOptionAppService>().To<ComponentFeaturesOptionAppService>();
            kernel.Bind<IComponentMenuOptionAppService>().To<ComponentMenuOptionAppService>();
            kernel.Bind<IComponentPanelOptionAppService>().To<ComponentPanelOptionAppService>();
            kernel.Bind<IComponentPortfolioOptionAppService>().To<ComponentPortfolioOptionAppService>();
            kernel.Bind<IComponentPostOptionAppService>().To<ComponentPostOptionAppService>();
            kernel.Bind<IComponentPresentationOptionAppService>().To<ComponentPresentationOptionAppService>();
            kernel.Bind<IComponentPricingOptionAppService>().To<ComponentPricingOptionAppService>();
            kernel.Bind<IComponentProjectOptionAppService>().To<ComponentProjectOptionAppService>();
            kernel.Bind<IComponentScopeOptionAppService>().To<ComponentScopeOptionAppService>();
            kernel.Bind<IComponentServiceOptionAppService>().To<ComponentServiceOptionAppService>();
            kernel.Bind<IComponentSimpleProductOptionAppService>().To<ComponentSimpleProductOptionAppService>();
            kernel.Bind<IComponentSkillOptionAppService>().To<ComponentSkillOptionAppService>();
            kernel.Bind<IComponentSummaryOptionAppService>().To<ComponentSummaryOptionAppService>();
            kernel.Bind<IComponentTeamOptionAppService>().To<ComponentTeamOptionAppService>();
            kernel.Bind<IContentButtonOptionAppService>().To<ContentButtonOptionAppService>();
            kernel.Bind<IContentListOptionAppService>().To<ContentListOptionAppService>();
            kernel.Bind<IContentTextOptionAppService>().To<ContentTextOptionAppService>();              

            kernel.Bind<IAccountManagerAppService>().To<AccountManagerAppService>();

            //_________________________________________________________________

            //Ishopping.Domain.Service
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));

            kernel.Bind<IAdminFinancialPlanService>().To<AdminFinancialPlanService>();
            kernel.Bind<IAdminImageGalleryService>().To<AdminImageGalleryService>();
            kernel.Bind<IAdminSliderService>().To<AdminSliderService>();
            kernel.Bind<IAdminSliderConfigService>().To<AdminSliderConfigService>();
            kernel.Bind<IAdminSocialNetWorkService>().To<AdminSocialNetWorkService>();
            kernel.Bind<IAdminTemplateService>().To<AdminTemplateService>();
            kernel.Bind<IAdminViewDataService>().To<AdminViewDataService>();
            kernel.Bind<IAdminViewItemService>().To<AdminViewItemService>();
            kernel.Bind<IComponentActivityService>().To<ComponentActivityService>();
            kernel.Bind<IComponentActivityOptionService>().To<ComponentActivityOptionService>();
            kernel.Bind<IComponentBrandService>().To<ComponentBrandService>();
            kernel.Bind<IComponentClientService>().To<ComponentClientService>();
            kernel.Bind<IComponentExtraLinkService>().To<ComponentExtraLinkService>();
            kernel.Bind<IComponentFaqService>().To<ComponentFaqService>();
            kernel.Bind<IComponentFeaturesService>().To<ComponentFeaturesService>();
            kernel.Bind<IComponentPanelService>().To<ComponentPanelService>();
            kernel.Bind<IComponentPortofolioService>().To<ComponentPortofolioService>();
            kernel.Bind<IComponentPostService>().To<ComponentPostService>();
            kernel.Bind<IComponentPresentationService>().To<ComponentPresentationService>();
            kernel.Bind<IComponentPricingService>().To<ComponentPricingService>();
            kernel.Bind<IComponentProjectService>().To<ComponentProjectService>();
            kernel.Bind<IComponentScopeService>().To<ComponentScopeService>();
            kernel.Bind<IComponentServiceService>().To<ComponentServiceService>();
            kernel.Bind<IComponentSimpleProductService>().To<ComponentSimpleProductService>();
            kernel.Bind<IComponentSkillService>().To<ComponentSkillService>();
            kernel.Bind<IComponentSocialNetworkService>().To<ComponentSocialNetworkService>();
            kernel.Bind<IComponentSummaryService>().To<ComponentSummaryService>();
            kernel.Bind<IComponentTeamService>().To<ComponentTeamService>();
            kernel.Bind<IComponentTeamSocialNetworkService>().To<ComponentTeamSocialNetworkService>();
            kernel.Bind<IConfigUserAppearanceService>().To<ConfigUserAppearanceService>();
            kernel.Bind<IComponentMenuService>().To<ComponentMenuService>();
            kernel.Bind<IComponentThumbnailService>().To<ComponentThumbnailService>();            
            kernel.Bind<IConfigUserDisplayService>().To<ConfigUserDisplayService>();
            kernel.Bind<IConfigUserMaintenanceService>().To<ConfigUserMaintenanceService>();
            kernel.Bind<IConfigUserStyleClassService>().To<ConfigUserStyleClassService>();
            kernel.Bind<IConfigUserStyleColorService>().To<ConfigUserStyleColorService>();
            kernel.Bind<IConfigUserViewItemService>().To<ConfigUserViewItemService>();
            kernel.Bind<IConfigUserViewService>().To<ConfigUserViewService>();
            kernel.Bind<IContentButtonService>().To<ContentButtonService>();
            kernel.Bind<IContentIconService>().To<ContentIconService>();
            kernel.Bind<IContentListService>().To<ContentListService>();
            kernel.Bind<IContentSliderService>().To<ContentSliderService>();
            kernel.Bind<IContentTextService>().To<ContentTextService>();
            kernel.Bind<IContentVideoService>().To<ContentVideoService>();
            kernel.Bind<IECommerceProductCategoryService>().To<ECommerceProductCategoryService>();
            kernel.Bind<IECommerceProductGroupService>().To<ECommerceProductGroupService>();
            kernel.Bind<IECommerceProductService>().To<ECommerceProductService>();
            kernel.Bind<IECommerceProductSoldService>().To<ECommerceProductSoldService>();
            kernel.Bind<IECommerceShoppingListService>().To<ECommerceShoppingListService>();
            kernel.Bind<IAppViewService>().To<AppViewService>();
            kernel.Bind<ISupportErrorService>().To<SupportErrorService>();
            kernel.Bind<ISupportInfoService>().To<SupportInfoService>();
            kernel.Bind<ISupportNotificationService>().To<SupportNotificationService>();
            kernel.Bind<ISupportTransactionService>().To<SupportTransactionService>();
            kernel.Bind<ISupportTransactionStatusService>().To<SupportTransactionStatusService>();
            kernel.Bind<IUserFinancialHistoryService>().To<UserFinancialHistoryService>();
            kernel.Bind<IUserFinancialService>().To<UserFinancialService>();
            kernel.Bind<IUserImageGalleryService>().To<UserImageGalleryService>();
            kernel.Bind<IUserMenuService>().To<UserMenuService>();
            kernel.Bind<IUserMenuViewItemService>().To<UserMenuViewItemService>();
            kernel.Bind<IUserMenuViewService>().To<UserMenuViewService>();
            kernel.Bind<IUserRegisterProfileService>().To<UserRegisterProfileService>();
            kernel.Bind<IUserRegisterStandardService>().To<UserRegisterStandardService>();
            kernel.Bind<IUserSerializeViewDataService>().To<UserSerializeViewDataService>();

            kernel.Bind<IComponentBrandOptionService>().To<ComponentBrandOptionService>();
            kernel.Bind<IComponentClientOptionService>().To<ComponentClientOptionService>();
            kernel.Bind<IComponentExtraLinkOptionService>().To<ComponentExtraLinkOptionService>();
            kernel.Bind<IComponentFaqOptionService>().To<ComponentFaqOptionService>();
            kernel.Bind<IComponentFeaturesOptionService>().To<ComponentFeaturesOptionService>();
            kernel.Bind<IComponentMenuOptionService>().To<ComponentMenuOptionService>();
            kernel.Bind<IComponentPanelOptionService>().To<ComponentPanelOptionService>();
            kernel.Bind<IComponentPortfolioOptionService>().To<ComponentPortfolioOptionService>();
            kernel.Bind<IComponentPostOptionService>().To<ComponentPostOptionService>();
            kernel.Bind<IComponentPresentationOptionService>().To<ComponentPresentationOptionService>();
            kernel.Bind<IComponentPricingOptionService>().To<ComponentPricingOptionService>();
            kernel.Bind<IComponentProjectOptionService>().To<ComponentProjectOptionService>();
            kernel.Bind<IComponentScopeOptionService>().To<ComponentScopeOptionService>();
            kernel.Bind<IComponentServiceOptionService>().To<ComponentServiceOptionService>();
            kernel.Bind<IComponentSimpleProductOptionService>().To<ComponentSimpleProductOptionService>();
            kernel.Bind<IComponentSkillOptionService>().To<ComponentSkillOptionService>();
            kernel.Bind<IComponentSummaryOptionService>().To<ComponentSummaryOptionService>();
            kernel.Bind<IComponentTeamOptionService>().To<ComponentTeamOptionService>();
            kernel.Bind<IContentButtonOptionService>().To<ContentButtonOptionService>();
            kernel.Bind<IContentListOptionService>().To<ContentListOptionService>();
            kernel.Bind<IContentTextOptionService>().To<ContentTextOptionService>();           

            kernel.Bind<IAccountManagerService>().To<AccountManagerService>();

            //_________________________________________________________________

            //Ishopping.Domain.Service
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            kernel.Bind<IAdminFinancialPlanRepository>().To<AdminFinancialPlanRepository>();
            kernel.Bind<IAdminImageGalleryRepository>().To<AdminImageGalleryRepository>();
            kernel.Bind<IAdminSliderRepository>().To<AdminSliderRepository>();
            kernel.Bind<IAdminSliderConfigRepository>().To<AdminSliderConfigRepository>();
            kernel.Bind<IAdminSocialNetWorkRepository>().To<AdminSocialNetWorkRepository>();
            kernel.Bind<IAdminTemplateRepository>().To<AdminTemplateRepository>();
            kernel.Bind<IAdminViewDataRepository>().To<AdminViewDataRepository>();
            kernel.Bind<IAdminViewItemRepository>().To<AdminViewItemRepository>();
            kernel.Bind<IComponentActivityRepository>().To<ComponentActivityRepository>();
            kernel.Bind<IComponentActivityOptionRepository>().To<ComponentActivityOptionRepository>();
            kernel.Bind<IComponentBrandRepository>().To<ComponentBrandRepository>();
            kernel.Bind<IComponentClientRepository>().To<ComponentClientRepository>();
            kernel.Bind<IComponentExtraLinkRepository>().To<ComponentExtraLinkRepository>();
            kernel.Bind<IComponentFaqRepository>().To<ComponentFaqRepository>();
            kernel.Bind<IComponentFeaturesRepository>().To<ComponentFeaturesRepository>();
            kernel.Bind<IComponentPanelRepository>().To<ComponentPanelRepository>();
            kernel.Bind<IComponentPortofolioRepository>().To<ComponentPortofolioRepository>();
            kernel.Bind<IComponentPostRepository>().To<ComponentPostRepository>();
            kernel.Bind<IComponentPresentationRepository>().To<ComponentPresentationRepository>();
            kernel.Bind<IComponentPricingRepository>().To<ComponentPricingRepository>();
            kernel.Bind<IComponentProjectRepository>().To<ComponentProjectRepository>();
            kernel.Bind<IComponentScopeRepository>().To<ComponentScopeRepository>();
            kernel.Bind<IComponentServiceRepository>().To<ComponentServiceRepository>();
            kernel.Bind<IComponentSimpleProductRepository>().To<ComponentSimpleProductRepository>();
            kernel.Bind<IComponentSkillRepository>().To<ComponentSkillRepository>();
            kernel.Bind<IComponentSocialNetworkRepository>().To<ComponentSocialNetworkRepository>();
            kernel.Bind<IComponentSummaryRepository>().To<ComponentSummaryRepository>();
            kernel.Bind<IComponentTeamRepository>().To<ComponentTeamRepository>();
            kernel.Bind<IComponentTeamSocialNetworkRepository>().To<ComponentTeamSocialNetworkRepository>();
            kernel.Bind<IComponentThumbnailRepository>().To<ComponentThumbnailRepository>();            
            kernel.Bind<IConfigUserAppearanceRepository>().To<ConfigUserAppearanceRepository>();
            kernel.Bind<IComponentMenuRepository>().To<ComponentMenuRepository>();
            kernel.Bind<IConfigUserDisplayRepository>().To<ConfigUserDisplayRepository>();
            kernel.Bind<IConfigUserMaintenanceRepository>().To<ConfigUserMaintenanceRepository>();
            kernel.Bind<IConfigUserStyleClassRepository>().To<ConfigUserStyleClassRepository>();
            kernel.Bind<IConfigUserStyleColorRepository>().To<ConfigUserStyleColorRepository>();
            kernel.Bind<IConfigUserViewItemRepository>().To<ConfigUserViewItemRepository>();
            kernel.Bind<IConfigUserViewRepository>().To<ConfigUserViewRepository>();
            kernel.Bind<IContentButtonRepository>().To<ContentButtonRepository>();
            kernel.Bind<IContentIconRepository>().To<ContentIconRepository>();
            kernel.Bind<IContentListRepository>().To<ContentListRepository>();
            kernel.Bind<IContentSliderRepository>().To<ContentSliderRepository>();
            kernel.Bind<IContentTextRepository>().To<ContentTextRepository>();
            kernel.Bind<IContentVideoRepository>().To<ContentVideoRepository>();
            kernel.Bind<IECommerceProductCategoryRepository>().To<ECommerceProductCategoryRepository>();
            kernel.Bind<IECommerceProductGroupRepository>().To<ECommerceProductGroupRepository>();
            kernel.Bind<IECommerceProductRepository>().To<ECommerceProductRepository>();
            kernel.Bind<IECommerceProductSoldRepository>().To<ECommerceProductSoldRepository>();
            kernel.Bind<IECommerceShoppingListRepository>().To<ECommerceShoppingListRepository>();
            kernel.Bind<IAppViewRepository>().To<AppViewRepository>();
            kernel.Bind<ISupportErrorRepository>().To<SupportErrorRepository>();
            kernel.Bind<ISupportInfoRepository>().To<SupportInfoRepository>();
            kernel.Bind<ISupportNotificationRepository>().To<SupportNotificationRepository>();
            kernel.Bind<ISupportTransactionRepository>().To<SupportTransactionRepository>();
            kernel.Bind<ISupportTransactionStatusRepository>().To<SupportTransactionStatusRepository>(); 
            kernel.Bind<IUserFinancialHistoryRepository>().To<UserFinancialHistoryRepository>();
            kernel.Bind<IUserFinancialRepository>().To<UserFinancialRepository>();
            kernel.Bind<IUserImageGalleryRepository>().To<UserImageGalleryRepository>();
            kernel.Bind<IUserMenuRepository>().To<UserMenuRepository>();
            kernel.Bind<IUserMenuViewItemRepository>().To<UserMenuViewItemRepository>();
            kernel.Bind<IUserMenuViewRepository>().To<UserMenuViewRepository>();
            kernel.Bind<IUserRegisterProfileRepository>().To<UserRegisterProfileRepository>();
            kernel.Bind<IUserRegisterStandardRepository>().To<UserRegisterStandardRepository>();
            kernel.Bind<IUserSerializeViewDataRepository>().To<UserSerializeViewDataRepository>();

            kernel.Bind<IComponentBrandOptionRepository>().To<ComponentBrandOptionRepository>();
            kernel.Bind<IComponentClientOptionRepository>().To<ComponentClientOptionRepository>();
            kernel.Bind<IComponentExtraLinkOptionRepository>().To<ComponentExtraLinkOptionRepository>();
            kernel.Bind<IComponentFaqOptionRepository>().To<ComponentFaqOptionRepository>();
            kernel.Bind<IComponentFeaturesOptionRepository>().To<ComponentFeaturesOptionRepository>();
            kernel.Bind<IComponentMenuOptionRepository>().To<ComponentMenuOptionRepository>();
            kernel.Bind<IComponentPanelOptionRepository>().To<ComponentPanelOptionRepository>();
            kernel.Bind<IComponentPortfolioOptionRepository>().To<ComponentPortfolioOptionRepository>();
            kernel.Bind<IComponentPostOptionRepository>().To<ComponentPostOptionRepository>();
            kernel.Bind<IComponentPresentationOptionRepository>().To<ComponentPresentationOptionRepository>();
            kernel.Bind<IComponentPricingOptionRepository>().To<ComponentPricingOptionRepository>();
            kernel.Bind<IComponentProjectOptionRepository>().To<ComponentProjectOptionRepository>();
            kernel.Bind<IComponentScopeOptionRepository>().To<ComponentScopeOptionRepository>();
            kernel.Bind<IComponentServiceOptionRepository>().To<ComponentServiceOptionRepository>();
            kernel.Bind<IComponentSimpleProductOptionRepository>().To<ComponentSimpleProductOptionRepository>();
            kernel.Bind<IComponentSkillOptionRepository>().To<ComponentSkillOptionRepository>();
            kernel.Bind<IComponentSummaryOptionRepository>().To<ComponentSummaryOptionRepository>();
            kernel.Bind<IComponentTeamOptionRepository>().To<ComponentTeamOptionRepository>();
            kernel.Bind<IContentButtonOptionRepository>().To<ContentButtonOptionRepository>();
            kernel.Bind<IContentListOptionRepository>().To<ContentListOptionRepository>();
            kernel.Bind<IContentTextOptionRepository>().To<ContentTextOptionRepository>();          

            kernel.Bind<IDeleteContentRepository>().To<DeleteContentRepository>();
            kernel.Bind<IDeleteComponentRepository>().To<DeleteComponentRepository>();
            kernel.Bind<IEntityOptionRepository>().To<EntityOptionRepository>(); 

            // ViewModels
            kernel.Bind<IndexOxygenViewModelSerialize>().To<IndexOxygenViewModelSerialize>();
            kernel.Bind<IndexCyprassViewModelSerialize>().To<IndexCyprassViewModelSerialize>();
            kernel.Bind<IndexTechgutViewModelSerialize>().To<IndexTechgutViewModelSerialize>();

            // AppViewModels
            kernel.Bind<IAppPortfolioAppService>().To<AppPortfolioAppService>();
            kernel.Bind<IAppStoreAppService>().To<AppStoreAppService>();


            // Dapper ConfigUserDisplayDapperRepository
            kernel.Bind<IAdminFinancialPlanDapperRepository>().To<AdminFinancialPlanDapperRepository>();
            kernel.Bind<IAdminImageGalleryDapperRepository>().To<AdminImageGalleryDapperRepository>();
            kernel.Bind<IAdminViewDataDapperRepository>().To<AdminViewDataDapperRepository>();
            kernel.Bind<IConfigUserMaintenanceDapperRepository>().To<ConfigUserMaintenanceDapperRepository>();
            kernel.Bind<IConfigUserDisplayDapperRepository>().To<ConfigUserDisplayDapperRepository>();
            kernel.Bind<IConfigUserStyleClassDapperRepository>().To<ConfigUserStyleClassDapperRepository>();
            kernel.Bind<IConfigUserViewItemDapperRepository>().To<ConfigUserViewItemDapperRepository>();
            kernel.Bind<IUserFinancialDapperRepository>().To<UserFinancialDapperRepository>();
            kernel.Bind<IUserFinancialHistoryDapperRepository>().To<UserFinancialHistoryDapperRepository>();
            kernel.Bind<IUserMenuDapperRepository>().To<UserMenuDapperRepository>();
            kernel.Bind<IUserImageGalleryDapperRepository>().To<UserImageGalleryDapperRepository>();
            kernel.Bind<IUserRegisterProfileDapperRepository>().To<UserRegisterProfileDapperRepository>();
            kernel.Bind<IUserSerializeViewDataDapperRepository>().To<UserSerializeViewDataDapperRepository>();

            kernel.Bind<IComponentActivityDapperRepository>().To<ComponentActivityDapperRepository>();
            kernel.Bind<IComponentBrandDapperRepository>().To<ComponentBrandDapperRepository>();
            kernel.Bind<IComponentClientDapperRepository>().To<ComponentClientDapperRepository>();
            kernel.Bind<IComponentExtraLinkDapperRepository>().To<ComponentExtraLinkDapperRepository>();
            kernel.Bind<IComponentFaqDapperRepository>().To<ComponentFaqDapperRepository>();
            kernel.Bind<IComponentFeaturesDapperRepository>().To<ComponentFeaturesDapperRepository>();
            kernel.Bind<IComponentMenuDapperRepository>().To<ComponentMenuDapperRepository>();
            kernel.Bind<IComponentPanelDapperRepository>().To<ComponentPanelDapperRepository>();
            kernel.Bind<IComponentPortofolioDapperRepository>().To<ComponentPortofolioDapperRepository>();
            kernel.Bind<IComponentPostDapperRepository>().To<ComponentPostDapperRepository>();
            kernel.Bind<IComponentPresentationDapperRepository>().To<ComponentPresentationDapperRepository>();
            kernel.Bind<IComponentPricingDapperRepository>().To<ComponentPricingDapperRepository>();
            kernel.Bind<IComponentProjectDapperRepository>().To<ComponentProjectDapperRepository>();
            kernel.Bind<IComponentScopeDapperRepository>().To<ComponentScopeDapperRepository>();
            kernel.Bind<IComponentServiceDapperRepository>().To<ComponentServiceDapperRepository>();
            kernel.Bind<IComponentSimpleProductDapperRepository>().To<ComponentSimpleProductDapperRepository>();
            kernel.Bind<IComponentSkillDapperRepository>().To<ComponentSkillDapperRepository>();
            kernel.Bind<IComponentSocialNetworkDapperRepository>().To<ComponentSocialNetworkDapperRepository>();
            kernel.Bind<IComponentSummaryDapperRepository>().To<ComponentSummaryDapperRepository>();
            kernel.Bind<IComponentTeamDapperRepository>().To<ComponentTeamDapperRepository>();            
            kernel.Bind<IComponentThumbnailDapperRepository>().To<ComponentThumbnailDapperRepository>();

            kernel.Bind<IContentButtonDapperRepository>().To<ContentButtonDapperRepository>();
            kernel.Bind<IContentIconDapperRepository>().To<ContentIconDapperRepository>();
            kernel.Bind<IContentListDapperRepository>().To<ContentListDapperRepository>();
            kernel.Bind<IContentSliderDapperRepository>().To<ContentSliderDapperRepository>();
            kernel.Bind<IContentTextDapperRepository>().To<ContentTextDapperRepository>();
            kernel.Bind<IContentVideoDapperRepository>().To<ContentVideoDapperRepository>();
           
     
        }        
    }
}
