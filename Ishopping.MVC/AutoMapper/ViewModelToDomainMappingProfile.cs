using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.AutoMapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using Ishopping.Mvc.Serialization.Content;
using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {   
            Mapper.CreateMap<AdminTemplate, AdminTemplateViewModel>();
            Mapper.CreateMap<AdminViewData, AdminViewData_ViewModel>();       
            Mapper.CreateMap<AdminImageGallery, AdminImageGalleryViewModel>();
            Mapper.CreateMap<AdminSlider, AdminSliderViewModel>();
            Mapper.CreateMap<AdminSliderConfig, AdminSliderConfigViewModel>();
            Mapper.CreateMap<AdminSocialNetWork, AdminSocialNetWorkViewModel>();
            Mapper.CreateMap<AdminViewItem, AdminViewItem_ViewModel>();
            Mapper.CreateMap<AdminFinancialPlan, AdminFinancialPlanViewModel>();
                    
            Mapper.CreateMap<ComponentBrand, ComponentBrandViewModel>();
            Mapper.CreateMap<ComponentClient, ComponentClientViewModel>();
            Mapper.CreateMap<ComponentMenu, ComponentMenuViewModel>();
            Mapper.CreateMap<ComponentThumbnail, ComponentThumbnailViewModel>();
            Mapper.CreateMap<ComponentPortofolio, ComponentPortofolioViewModel>();
            Mapper.CreateMap<ComponentPost, ComponentPostViewModel>();
            Mapper.CreateMap<ComponentPresentation, ComponentPresentationViewModel>();
            Mapper.CreateMap<ComponentProject, ComponentProjectViewModel>();
            Mapper.CreateMap<ComponentService, ComponentServiceViewModel>();
            Mapper.CreateMap<ComponentSimpleProduct, ComponentSimpleProductViewModel>();
            Mapper.CreateMap<ComponentTeam, ComponentTeamViewModel>();
            Mapper.CreateMap<ComponentTeamSocialNetwork, ComponentTeamSocialNetworkViewModel>();
            Mapper.CreateMap<ComponentSocialNetwork, ComponentSocialNetworkViewModel>();

            Mapper.CreateMap<ContentSlider, ContentSliderViewModel>();

            Mapper.CreateMap<ConfigUserAppearance, ConfigUserAppearanceViewModel>();
            Mapper.CreateMap<ConfigUserDisplay, ConfigUserDisplayViewModel>();
            Mapper.CreateMap<ConfigUserMaintenance, ConfigUserMaintenanceViewModel>();
            Mapper.CreateMap<ConfigUserMaintenance, MaintenanceViewModel>();
            Mapper.CreateMap<ConfigUserStyleColor, ConfigUserStyleColorViewModel>();

            Mapper.CreateMap<UserFinancial, UserFinancialViewModel>();
            Mapper.CreateMap<UserFinancialHistory, UserFinancialHistoryViewModel>();
            Mapper.CreateMap<UserImageGallery, UserImageGalleryViewModel>();
            Mapper.CreateMap<UserMenuView, UserMenuView_ViewModel>();
            Mapper.CreateMap<UserMenuViewItem, UserMenuViewItemViewModel>();
            Mapper.CreateMap<UserRegisterProfile, UserRegisterProfileViewModel>();
            Mapper.CreateMap<UserRegisterProfile, UserAccountViewModel>();

            Mapper.CreateMap<ECommerceProduct, ECommerceProductViewModel>();

            Mapper.CreateMap<ImageGalleryResponse, ImageGalleryResponseViewModel>();

            // Option for component
            Mapper.CreateMap<ComponentBrandOption, ComponentBrandOptionModel>();
            Mapper.CreateMap<ComponentClientOption, ComponentClientOptionModel>();
            Mapper.CreateMap<ComponentMenuOption, ComponentMenuOptionModel>();
            Mapper.CreateMap<ComponentPortofolioOption, ComponentPortofolioOptionModel>();
            Mapper.CreateMap<ComponentPostOption, ComponentPostOptionModel>();
            Mapper.CreateMap<ComponentPresentationOption, ComponentPresentationOptionModel>();
            Mapper.CreateMap<ComponentProjectOption, ComponentProjectOptionModel>();
            Mapper.CreateMap<ComponentServiceOption, ComponentServiceOptionModel>();
            Mapper.CreateMap<ComponentSimpleProductOption, ComponentSimpleProductOptionModel>();
            Mapper.CreateMap<ComponentTeamOption, ComponentTeamOptionModel>();

            // Serialization
            Mapper.CreateMap<ComponentActivity, ComponentActivitySerialization>();
            Mapper.CreateMap<ComponentBrand, ComponentBrandSerialization>();
            Mapper.CreateMap<ComponentClient, ComponentClientSerialization>();
            Mapper.CreateMap<ComponentExtraLink, ComponentExtraLinkSerialization>();
            Mapper.CreateMap<ComponentFaq, ComponentFaqSerialization>();
            Mapper.CreateMap<ComponentFeatures, ComponentFeaturesSerialization>();
            Mapper.CreateMap<ComponentMenu, ComponentMenuSerialization>();
            Mapper.CreateMap<ComponentPanel, ComponentPanelSerialization>();
            Mapper.CreateMap<ComponentPortofolio, ComponentPortofolioSerialization>();
            Mapper.CreateMap<ComponentPost, ComponentPostSerialization>();
            Mapper.CreateMap<ComponentPresentation, ComponentPresentationSerialization>();            
            Mapper.CreateMap<ComponentProject, ComponentProjectSerialization>();
            Mapper.CreateMap<ComponentScope, ComponentScopeSerialization>();
            Mapper.CreateMap<ComponentService, ComponentServiceSerialization>();
            Mapper.CreateMap<ComponentSimpleProduct, ComponentSimpleProductSerialization>();
            Mapper.CreateMap<ComponentSkill, ComponentSkillSerialization>();
            Mapper.CreateMap<ComponentSocialNetwork, ComponentSocialNetworkSerialization>();
            Mapper.CreateMap<ComponentSummary, ComponentSummarySerialization>();
            Mapper.CreateMap<ComponentTeam, ComponentTeamSerialization>();
            Mapper.CreateMap<ComponentTeamSocialNetwork, ComponentTeamSocialNetworkSerialization>();
            Mapper.CreateMap<ComponentThumbnail, ComponentThumbnailSerialization>();

            Mapper.CreateMap<ContentSlider, ContentSliderSerialization>();

            Mapper.CreateMap<UserImageGallery, UserImageGallerySerialization>();
            Mapper.CreateMap<UserMenuViewItem, UserMenuViewItemSerialization>();
            Mapper.CreateMap<UserMenuView, UserMenuViewSerialization>();

            // Serialization Custom
            Mapper.CreateMap<ComponentPricing, ComponentPricingSerialization>()
                .ForMember(x => x.Description, map => map.AddFormatter<ListFormat>());

            Mapper.CreateMap<UserRegisterProfile, UserRegisterProfileSerialization>()                
                .ForMember(x => x.Telefone, map => map.AddFormatter<TelFormat>())
                .ForMember(x => x.Telefone2, map => map.AddFormatter<TelFormat>())
                .ForMember(x => x.WhatsApp, map => map.AddFormatter<TelFormat>());

            // Option for serialization
            Mapper.CreateMap<ComponentActivityOption, ComponentActivityOptionSerialization>();
            Mapper.CreateMap<ComponentBrandOption, ComponentBrandOptionSerialization>();
            Mapper.CreateMap<ComponentClientOption, ComponentClientOptionSerialization>();
            Mapper.CreateMap<ComponentExtraLinkOption, ComponentExtraLinkOptionSerialization>();
            Mapper.CreateMap<ComponentFaqOption, ComponentFaqOptionSerialization>();
            Mapper.CreateMap<ComponentFeaturesOption, ComponentFeaturesOptionSerialization>();
            Mapper.CreateMap<ComponentMenuOption, ComponentMenuOptionSerialization>();
            Mapper.CreateMap<ComponentPanelOption, ComponentPanelOptionSerialization>();
            Mapper.CreateMap<ComponentPortofolioOption, ComponentPortofolioOptionSerialization>();
            Mapper.CreateMap<ComponentPostOption, ComponentPostOptionSerialization>();
            Mapper.CreateMap<ComponentPresentationOption, ComponentPresentationOptionSerialization>();
            Mapper.CreateMap<ComponentPricingOption, ComponentPricingOptionSerialization>();
            Mapper.CreateMap<ComponentProjectOption, ComponentProjectOptionSerialization>();
            Mapper.CreateMap<ComponentScopeOption, ComponentScopeOptionSerialization>();
            Mapper.CreateMap<ComponentServiceOption, ComponentServiceOptionSerialization>();
            Mapper.CreateMap<ComponentSimpleProductOption, ComponentSimpleProductOptionSerialization>();
            Mapper.CreateMap<ComponentSkillOption, ComponentSkillOptionSerialization>();
            Mapper.CreateMap<ComponentSummaryOption, ComponentSummaryOptionSerialization>();
            Mapper.CreateMap<ComponentTeamOption, ComponentTeamOptionSerialization>();

            //Ishopping
            Mapper.CreateMap<SinglePost, SinglePostSectionModel>();
            Mapper.CreateMap<SimplePost, BlogViewModel>();
            Mapper.CreateMap<SimplePost, PostSummarySectionModel>();
             

            // Admin Only
            Mapper.CreateMap<ProfileContact, UserProfileContactViewModel>();        
        }
    }
}