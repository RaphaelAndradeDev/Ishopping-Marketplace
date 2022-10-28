using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.Mvc.Serialization.User;
using Ishopping.MVC.SectionModels.ComponentDeserialize;
using Ishopping.MVC.SectionModels.ComponentSerialize;
using Ishopping.SectionModels.Content;
using Ishopping.SectionModels.User;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ishopping.ViewModels.TemplateDefault
{
    public class IndexDefaultViewModelDeserialize
    {
        // Css
        public List<string> CssFile { get; set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; set; }

        // Content
        public List<string> ImagensForm { get; set; }
        public List<string> ImagensIcon { get; set; }
        public List<string> ImagensLogo { get; set; }
        public List<ButtonModels> Buttons { get; set; }
        public List<TextModels> Textos { get; set; }
        public List<string> Videos { get; set; }

        // Component
        public ComponentActivitySectionModelDeserialize ItemActivity { get; set; }
        public ComponentBrandSectionModelDeserialize ItemBrand { get; set; }
        public ComponentClientSectionModelDeserialize ItemClient { get; set; }
        public ComponentExtraLinkSectionModelDeserialize ItemExtraLink { get; set; }
        public ComponentFaqSectionModelDeserialize ItemFaq { get; set; }
        public ComponentFeaturesSectionModelDeserialize ItemFeatures { get; set; }
        public ComponentMenuSectionModelDeserialize ItemMenu { get; set; }
        public ComponentPanelSectionModelDeserialize ItemPanel { get; set; }
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }
        public ComponentPostSectionModelDeserialize ItemPost { get; set; }
        public ComponentPresentationSectionModelDeserialize ItemPresentation { get; set; }
        public ComponentPricingSectionModelDeserialize ItemPricing { get; set; }
        public ComponentProjectSectionModelDeserialize ItemProject { get; set; }
        public ComponentScopeSectionModelDeserialize ItemScope { get; set; }
        public ComponentServiceSectionModelDeserialize ItemService { get; set; }
        public ComponentSimpleProductSectionModelDeserialize ItemSimpleProduct { get; set; }
        public ComponentSkillSectionModelDeserialize ItemSkill { get; set; }
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }
        public ComponentSummarySectionModelDeserialize ItemSummary { get; set; }
        public ComponentTeamSectionModelDeserialize ItemTeam { get; set; }
        public ComponentThumbnailSectionModelDeserialize ItemThumbnail { get; set; }
    }
    public class IndexDefaultViewModelSerialize
    {
        const int viewCod = 1000;

        // Admin
        private readonly IAdminImageGalleryAppService _adminImageGallery;
        private readonly IAdminTemplateAppService _adminTemplate;
        private readonly IAdminViewDataAppService _adminViewData;
        
        // Config
        private readonly IConfigUserViewItemAppService _configUserViewItem;

        // User
        private readonly IUserImageGalleryAppService _userImageGallery;
        private readonly IUserMenuAppService _userMenu;        
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        // Content        
        private readonly IContentButtonAppService _contentButton;
        private readonly IContentTextAppService _contentText;
        private readonly IContentVideoAppService _contentVideo;
        
        // Component
        private readonly IComponentActivityAppService _componentActivity;
        private readonly IComponentBrandAppService _componentBrand;
        private readonly IComponentClientAppService _componentClient;
        private readonly IComponentExtraLinkAppService _componentExtraLink;
        private readonly IComponentFaqAppService _componentFaq;
        private readonly IComponentFeaturesAppService _componentFeatures;
        private readonly IComponentMenuAppService _componentMenu;
        private readonly IComponentPanelAppService _componentPanel;
        private readonly IComponentPortofolioAppService _componentPortfolio;
        private readonly IComponentPostAppService _componentPost;
        private readonly IComponentPresentationAppService _componentPresentation;
        private readonly IComponentPricingAppService _componentPricing;
        private readonly IComponentProjectAppService _componentProject;
        private readonly IComponentScopeAppService _componentScope;
        private readonly IComponentServiceAppService _componentService;
        private readonly IComponentSimpleProductAppService _componentSimpleProduct;
        private readonly IComponentSkillAppService _componentSkill;
        private readonly IComponentSocialNetworkAppService _componentSocialNetwork;
        private readonly IComponentSummaryAppService _componentSummary;
        private readonly IComponentTeamAppService _componentTeam;
        private readonly IComponentThumbnailAppService _componentThumbnail;
        
        // Css
        public List<string> CssFile { get; private set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; private set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; private set; }        

        // Content
        public List<string> ImagensForm{ get; private set; }
        public List<string> ImagensIcon { get; private set; }
        public List<string> ImagensLogo { get; private set; }
        public List<ButtonModels> Buttons { get; private set; }
        public List<TextModels> Textos { get; private set; }
        public List<string> Videos { get; private set; }

        // Component
        public ComponentActivitySectionModelSerialize ItemActivity { get; private set; }
        public ComponentBrandSectionModelSerialize ItemBrand { get; private set; }
        public ComponentClientSectionModelSerialize ItemClient { get; private set; }
        public ComponentExtraLinkSectionModelSerialize ItemExtraLink { get; private set; }
        public ComponentFaqSectionModelSerialize ItemFaq { get; private set; }
        public ComponentFeaturesSectionModelSerialize ItemFeatures { get; private set; }
        public ComponentMenuSectionModelSerialize ItemMenu { get; private set; }
        public ComponentPanelSectionModelSerialize ItemPanel { get; private set; }
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }
        public ComponentPostSectionModelSerialize ItemPost { get; private set; }
        public ComponentPresentationSectionModelSerialize ItemPresentation { get; private set; }
        public ComponentPricingSectionModelSerialize ItemPricing { get; private set; }
        public ComponentProjectSectionModelSerialize ItemProject { get; private set; }
        public ComponentScopeSectionModelSerialize ItemScope { get; private set; }
        public ComponentServiceSectionModelSerialize ItemService { get; private set; }
        public ComponentSimpleProductSectionModelSerialize ItemSimpleProduct { get; private set; }
        public ComponentSkillSectionModelSerialize ItemSkill { get; private set; }
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; }
        public ComponentSummarySectionModelSerialize ItemSummary { get; private set; }
        public ComponentTeamSectionModelSerialize ItemTeam { get; private set; }
        public ComponentThumbnailSectionModelSerialize ItemThumbnail { get; private set; }

        // Ctor
        public IndexDefaultViewModelSerialize(

            // Admin
            IAdminImageGalleryAppService adminImageGallery,
            IAdminTemplateAppService adminTemplate,
            IAdminViewDataAppService adminViewData,
            
            // Config
            IConfigUserViewItemAppService configUserViewItem,

            // User
            IUserImageGalleryAppService userImageGallery,
            IUserMenuAppService userMenu,
            IUserRegisterProfileAppService userRegisterProfile,

            // Content
            IContentButtonAppService contentButton,
            IContentTextAppService contentText,
            IContentVideoAppService contentVideo,

            // Component      
            IComponentActivityAppService componentActivity,
            IComponentBrandAppService componentBrand,
            IComponentClientAppService componentClient,
            IComponentExtraLinkAppService componentExtraLink,
            IComponentFaqAppService componentFaq,
            IComponentFeaturesAppService componentFeatures,
            IComponentMenuAppService componentMenu,
            IComponentPanelAppService componentPanel,
            IComponentPortofolioAppService componentPortfolio,
            IComponentPostAppService componentPost,
            IComponentPresentationAppService componentPresentation,
            IComponentPricingAppService componentPricing,
            IComponentProjectAppService componentProject,
            IComponentScopeAppService componentScope,
            IComponentServiceAppService componentService,
            IComponentSimpleProductAppService componentSimpleProduct,
            IComponentSkillAppService componentSkill,
            IComponentSocialNetworkAppService componentSocialNetwork,
            IComponentSummaryAppService componentSummary,
            IComponentTeamAppService componentTeam,
            IComponentThumbnailAppService componentThumbnail          
            )
        {
            // Admin        
            _adminImageGallery = adminImageGallery;
            _adminTemplate = adminTemplate;
            _adminViewData = adminViewData;       
                       
            // Config
            _configUserViewItem = configUserViewItem;

            // User
            _userImageGallery = userImageGallery;
            _userMenu = userMenu;
            _userRegisterProfile = userRegisterProfile;

            // Content
            _contentButton = contentButton;
            _contentText = contentText;
            _contentVideo = contentVideo;

            // Component
            _componentActivity = componentActivity;
            _componentBrand = componentBrand;
            _componentClient = componentClient;
            _componentExtraLink = componentExtraLink;
            _componentFaq = componentFaq;
            _componentFeatures = componentFeatures;
            _componentMenu = componentMenu;
            _componentPanel = componentPanel;
            _componentPortfolio = componentPortfolio;
            _componentPost = componentPost;
            _componentPresentation = componentPresentation;
            _componentPricing = componentPricing;
            _componentProject = componentProject;  
            _componentScope = componentScope;
            _componentService = componentService;
            _componentSimpleProduct = componentSimpleProduct;
            _componentSkill = componentSkill;
            _componentSocialNetwork = componentSocialNetwork;
            _componentSummary = componentSummary;
            _componentTeam = componentTeam;
            _componentThumbnail = componentThumbnail;                                                                 
        }

        public void ExecuteViewModel(int siteNumber)
        {
            var viewData = _adminViewData.GetByViewCod(viewCod);
            var viewItens = _configUserViewItem.GetAllBySiteNumber(siteNumber);            

            // Profile  
            var userRegisterProfile = _userRegisterProfile.GetBySiteNumber(siteNumber);
            this.Profile = Mapper.Map<UserRegisterProfile, UserRegisterProfileSerialization>(userRegisterProfile);

            // Css
            this.CssFile = GetCssFileName(userRegisterProfile.TemplateCod);

            // Menu
            var userMenuView = _userMenu.GetMenuBySiteNumber(siteNumber).UserMenuView.Where(x => x.Activated == true && x.OnMenu == true).ToList();
            this.Menu = Mapper.Map<IEnumerable<UserMenuView>, IEnumerable<UserMenuViewSerialization>>(userMenuView);

            // Images 
            this.ImagensForm = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 1, viewCod, viewData).ListImage;
            this.ImagensIcon = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 2, viewCod, viewData).ListImage;
            this.ImagensLogo = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 3, viewCod, viewData).ListImage;

            // Content                     
            this.Buttons = new ContentButtonSectionModel(siteNumber, _contentButton, viewData).ListButton;
            this.Textos = new ContentTextSectionModel(siteNumber, _contentText, viewData).ListText;
            this.Videos = new ContentVideoSectionModel(siteNumber, _contentVideo, viewData).ListVideo;

            // Components
            this.ItemActivity = new ComponentActivitySectionModelSerialize(siteNumber, _componentActivity, viewItens);
            this.ItemBrand = new ComponentBrandSectionModelSerialize(siteNumber, _componentBrand, viewItens);
            this.ItemClient = new ComponentClientSectionModelSerialize(siteNumber, _componentClient, viewItens);
            this.ItemExtraLink = new ComponentExtraLinkSectionModelSerialize(siteNumber, _componentExtraLink, viewItens);
            this.ItemFaq = new ComponentFaqSectionModelSerialize(siteNumber, _componentFaq, viewItens);
            this.ItemFeatures = new ComponentFeaturesSectionModelSerialize(siteNumber, _componentFeatures, viewItens);
            this.ItemMenu = new ComponentMenuSectionModelSerialize(siteNumber, _componentMenu, viewItens);
            this.ItemPanel = new ComponentPanelSectionModelSerialize(siteNumber, _componentPanel, viewItens);
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);
            this.ItemPost = new ComponentPostSectionModelSerialize(siteNumber, _componentPost, viewItens);
            this.ItemPresentation = new ComponentPresentationSectionModelSerialize(siteNumber, _componentPresentation, viewItens);
            this.ItemPricing = new ComponentPricingSectionModelSerialize(siteNumber, _componentPricing, viewItens);
            this.ItemProject = new ComponentProjectSectionModelSerialize(siteNumber, _componentProject, viewItens);
            this.ItemScope = new ComponentScopeSectionModelSerialize(siteNumber, _componentScope, viewItens);
            this.ItemService = new ComponentServiceSectionModelSerialize(siteNumber, _componentService, viewItens);
            this.ItemSimpleProduct = new ComponentSimpleProductSectionModelSerialize(siteNumber, _componentSimpleProduct, viewItens);
            this.ItemSkill = new ComponentSkillSectionModelSerialize(siteNumber, _componentSkill, viewItens);
            this.ItemSocialNetwork = new ComponentSocialNetworkSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentSocialNetwork, viewItens);
            this.ItemSummary = new ComponentSummarySectionModelSerialize(siteNumber, _componentSummary, viewItens);
            this.ItemTeam = new ComponentTeamSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentTeam, viewItens);
            this.ItemThumbnail = new ComponentThumbnailSectionModelSerialize(siteNumber, _componentThumbnail, viewItens);
        }

        private List<string> GetCssFileName(int templateCod)
        {
            List<string> cssFileName = new List<string>();
            string[] cssPaths = _adminTemplate.GetByTemplateCod(templateCod).CssPath.Split(',');
            foreach (var item in cssPaths)
            {
                cssFileName.Add(Path.GetFileName(item));
            }
            return cssFileName;
        }
    }
}