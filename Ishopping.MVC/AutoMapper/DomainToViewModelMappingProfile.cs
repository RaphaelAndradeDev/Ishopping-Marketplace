using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using Ishopping.MVC.ViewModels.Component;
using Ishopping.MVC.ViewModels.Config;
using Ishopping.MVC.ViewModels.ECommerce;
using Ishopping.MVC.ViewModels.User;
using Ishopping.SectionModels.Ishopping;
using Ishopping.ViewModels.Admin;
using Ishopping.ViewModels.Content;
using Ishopping.ViewModels.Ishopping;
using Ishopping.ViewModels.User;

namespace Ishopping.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {       
            // Admin
            Mapper.CreateMap<AdminTemplateViewModel, AdminTemplate>();
            Mapper.CreateMap<AdminViewData_ViewModel, AdminViewData>();          
            Mapper.CreateMap<AdminImageGalleryViewModel, AdminImageGallery>();
            Mapper.CreateMap<AdminSliderViewModel, AdminSlider>();
            Mapper.CreateMap<AdminSliderConfigViewModel, AdminSliderConfig>();
            Mapper.CreateMap<AdminSocialNetWorkViewModel, AdminSocialNetWork>();
            Mapper.CreateMap<AdminViewItem_ViewModel, AdminViewItem>();
            Mapper.CreateMap<AdminFinancialPlanViewModel, AdminFinancialPlan>();

            // Content
            Mapper.CreateMap<ContentSliderViewModel, ContentSlider>();

            // Component
            Mapper.CreateMap<ComponentBrandViewModel, ComponentBrand>();
            Mapper.CreateMap<ComponentClientViewModel, ComponentClient>();
            Mapper.CreateMap<ComponentMenuViewModel, ComponentMenu>();
            Mapper.CreateMap<ComponentThumbnailViewModel, ComponentThumbnail>();
            Mapper.CreateMap<ComponentPortofolioViewModel, ComponentPortofolio>();
            Mapper.CreateMap<ComponentPostViewModel, ComponentPost>();
            Mapper.CreateMap<ComponentPresentationViewModel, ComponentPresentation>();
            Mapper.CreateMap<ComponentProjectViewModel, ComponentProject>();
            Mapper.CreateMap<ComponentServiceViewModel, ComponentService>();
            Mapper.CreateMap<ComponentSimpleProductViewModel, ComponentSimpleProduct>();
            Mapper.CreateMap<ComponentTeamViewModel, ComponentTeam>();
            Mapper.CreateMap<ComponentTeamSocialNetworkViewModel, ComponentTeamSocialNetwork>();
            Mapper.CreateMap<ComponentSocialNetworkViewModel, ComponentSocialNetwork>();
                        
            // Config
            Mapper.CreateMap<ConfigUserAppearanceViewModel, ConfigUserAppearance>();
            Mapper.CreateMap<ConfigUserDisplayViewModel, ConfigUserDisplay>();
            Mapper.CreateMap<ConfigUserMaintenanceViewModel, ConfigUserMaintenance>();
            Mapper.CreateMap<MaintenanceViewModel, ConfigUserMaintenance>();
            Mapper.CreateMap<ConfigUserStyleColorViewModel, ConfigUserStyleColor>();

            // User
            Mapper.CreateMap<UserFinancialViewModel, UserFinancial>();
            Mapper.CreateMap<UserFinancialHistoryViewModel, UserFinancialHistory>();
            Mapper.CreateMap<UserImageGalleryViewModel, UserImageGallery>();
            Mapper.CreateMap<UserMenuView_ViewModel, UserMenuView>();
            Mapper.CreateMap<UserMenuViewItemViewModel, UserMenuViewItem>();
            Mapper.CreateMap<UserRegisterProfileViewModel, UserRegisterProfile>();
            Mapper.CreateMap<UserAccountViewModel, UserRegisterProfile>();

            // Ecommerce
            Mapper.CreateMap<ECommerceProductViewModel, ECommerceProduct>();                       

            // Option for component
            Mapper.CreateMap<ComponentMenuOptionModel, ComponentMenuOption>();
            Mapper.CreateMap<ComponentPortofolioOptionModel, ComponentPortofolioOption>();                    

            // Other
            Mapper.CreateMap<ImageGalleryResponseViewModel, ImageGalleryResponse>();

            // Ishopping
            Mapper.CreateMap<SinglePostSectionModel, SinglePost>();
            Mapper.CreateMap<BlogViewModel, SimplePost>();
            Mapper.CreateMap<PostSummarySectionModel, SimplePost>();
       
        }
    }
}