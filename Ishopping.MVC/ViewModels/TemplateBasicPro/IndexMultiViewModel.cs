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

namespace Ishopping.ViewModels.TemplateBasicPro
{
    public class IndexMultiViewModelDeserialize
    {
        // Css
        public List<string> CssFile { get; set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; set; }

        // Content
        public List<string> ImagensForm { get; set; }  
        public List<string> ImagensLogo { get; set; }
        public List<ButtonModels> Buttons { get; set; }
        public List<TextModels> Textos { get; set; }
        public List<string> Videos { get; set; }

        // Component
        public ComponentActivitySectionModelDeserialize ItemActivity { get; set; }//       
        public ComponentClientSectionModelDeserialize ItemClient { get; set; }//        
        public ComponentFeaturesSectionModelDeserialize ItemFeatures { get; set; }//        
        public ComponentPanelSectionModelDeserialize ItemPanel { get; set; }//
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }//
        public ComponentPostSectionModelDeserialize ItemPost { get; set; }//        
        public ComponentPricingSectionModelDeserialize ItemPricing { get; set; }//       
        public ComponentScopeSectionModelDeserialize ItemScope { get; set; }//        
        public ComponentSkillSectionModelDeserialize ItemSkill { get; set; }//
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }//   
        public ComponentTeamSectionModelDeserialize ItemTeam { get; set; }//    
    }

    public class IndexMultiViewModelSerialize
    {
        const int viewCod = 3070;

        // Admin
        private readonly IAdminImageGalleryAppService _adminImageGallery;
        private readonly IAdminTemplateAppService _adminTemplate;
        private readonly IAdminViewDataAppService _adminViewData;

        // Config
        private readonly IConfigUserViewItemAppService _configUserViewItem;

        // User
        private readonly IUserImageGalleryAppService _userImageGallery;
        private readonly IUserMenuViewAppService _userMenuView;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        // Content        
        private readonly IContentButtonAppService _contentButton;
        private readonly IContentTextAppService _contentText;
        private readonly IContentVideoAppService _contentVideo;

        // Component
        private readonly IComponentActivityAppService _componentActivity;
        private readonly IComponentClientAppService _componentClient;   
        private readonly IComponentFeaturesAppService _componentFeatures;  
        private readonly IComponentPanelAppService _componentPanel;
        private readonly IComponentPortofolioAppService _componentPortfolio;
        private readonly IComponentPostAppService _componentPost;    
        private readonly IComponentPricingAppService _componentPricing;     
        private readonly IComponentScopeAppService _componentScope;
        private readonly IComponentSkillAppService _componentSkill;
        private readonly IComponentSocialNetworkAppService _componentSocialNetwork;
        private readonly IComponentTeamAppService _componentTeam;
  

        // Css
        public List<string> CssFile { get; private set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; private set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; private set; }

        // Content
        public List<string> ImagensForm { get; private set; }       
        public List<string> ImagensLogo { get; private set; }
        public List<ButtonModels> Buttons { get; private set; }
        public List<TextModels> Textos { get; private set; }
        public List<string> Videos { get; private set; }

        // Component
        public ComponentActivitySectionModelSerialize ItemActivity { get; private set; }   
        public ComponentClientSectionModelSerialize ItemClient { get; private set; }        
        public ComponentFeaturesSectionModelSerialize ItemFeatures { get; private set; }     
        public ComponentPanelSectionModelSerialize ItemPanel { get; private set; }
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }
        public ComponentPostSectionModelSerialize ItemPost { get; private set; }    
        public ComponentPricingSectionModelSerialize ItemPricing { get; private set; }    
        public ComponentScopeSectionModelSerialize ItemScope { get; private set; }     
        public ComponentSkillSectionModelSerialize ItemSkill { get; private set; }
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; }
        public ComponentTeamSectionModelSerialize ItemTeam { get; private set; }   

        // Ctor
        public IndexMultiViewModelSerialize(

            // Admin
            IAdminImageGalleryAppService adminImageGallery,
            IAdminTemplateAppService adminTemplate,
            IAdminViewDataAppService adminViewData,

            // Config
            IConfigUserViewItemAppService configUserViewItem,

            // User
            IUserImageGalleryAppService userImageGallery,
            IUserMenuViewAppService userMenuView,
            IUserRegisterProfileAppService userRegisterProfile,

            // Content
            IContentButtonAppService contentButton,
            IContentTextAppService contentText,
            IContentVideoAppService contentVideo,

            // Component      
            IComponentActivityAppService componentActivity,         
            IComponentClientAppService componentClient,      
            IComponentFeaturesAppService componentFeatures,   
            IComponentPanelAppService componentPanel,
            IComponentPortofolioAppService componentPortfolio,
            IComponentPostAppService componentPost,           
            IComponentPricingAppService componentPricing,
            IComponentScopeAppService componentScope,    
            IComponentSkillAppService componentSkill,
            IComponentSocialNetworkAppService componentSocialNetwork,        
            IComponentTeamAppService componentTeam     
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
            _userMenuView = userMenuView;
            _userRegisterProfile = userRegisterProfile;

            // Content
            _contentButton = contentButton;
            _contentText = contentText;
            _contentVideo = contentVideo;

            // Component
            _componentActivity = componentActivity;           
            _componentClient = componentClient;         
            _componentFeatures = componentFeatures;           
            _componentPanel = componentPanel;
            _componentPortfolio = componentPortfolio;
            _componentPost = componentPost;            
            _componentPricing = componentPricing;           
            _componentScope = componentScope;               
            _componentSkill = componentSkill;
            _componentSocialNetwork = componentSocialNetwork;         
            _componentTeam = componentTeam;          
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
            var userMenuView = _userMenuView.GetUserMenu(siteNumber);
            this.Menu = Mapper.Map<IEnumerable<UserMenuView>, IEnumerable<UserMenuViewSerialization>>(userMenuView);

            // Images 
            this.ImagensForm = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 1, viewCod, viewData).ListImage;           
            this.ImagensLogo = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 3, viewCod, viewData).ListImage;

            // Content                     
            this.Buttons = new ContentButtonSectionModel(siteNumber, _contentButton, viewData).ListButton;
            this.Textos = new ContentTextSectionModel(siteNumber, _contentText, viewData).ListText;
            this.Videos = new ContentVideoSectionModel(siteNumber, _contentVideo, viewData).ListVideo;

            // Components
            this.ItemActivity = new ComponentActivitySectionModelSerialize(siteNumber, _componentActivity, viewItens);        
            this.ItemClient = new ComponentClientSectionModelSerialize(siteNumber, _componentClient, viewItens);  
            this.ItemFeatures = new ComponentFeaturesSectionModelSerialize(siteNumber, _componentFeatures, viewItens);       
            this.ItemPanel = new ComponentPanelSectionModelSerialize(siteNumber, _componentPanel, viewItens);
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);
            this.ItemPost = new ComponentPostSectionModelSerialize(siteNumber, _componentPost, viewItens);       
            this.ItemPricing = new ComponentPricingSectionModelSerialize(siteNumber, _componentPricing, viewItens);           
            this.ItemScope = new ComponentScopeSectionModelSerialize(siteNumber, _componentScope, viewItens);           
            this.ItemSkill = new ComponentSkillSectionModelSerialize(siteNumber, _componentSkill, viewItens);
            this.ItemSocialNetwork = new ComponentSocialNetworkSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentSocialNetwork, viewItens);
            this.ItemTeam = new ComponentTeamSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentTeam, viewItens);                             
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