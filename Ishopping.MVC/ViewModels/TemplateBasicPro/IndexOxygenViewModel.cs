using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.Mvc.Serialization.Component;
using Ishopping.Mvc.Serialization.User;
using Ishopping.MVC.SectionModels.ComponentDeserialize;
using Ishopping.MVC.SectionModels.ComponentSerialize;
using Ishopping.SectionModels.Content;
using Ishopping.SectionModels.User;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Ishopping.MVC.ViewModels
{
    public class IndexOxygenViewModelDeserialize
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

        // Component     
        public ComponentActivitySectionModelDeserialize ItemActivity { get; set; }
        public ComponentSkillSectionModelDeserialize ItemSkill { get; set; }
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }
        public ComponentTeamSectionModelDeserialize ItemTeam { get; set; }
        public ComponentPricingSectionModelDeserialize ItemPricing { get; set; }
        public ComponentPostSectionModelDeserialize ItemPost { get; set; }
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }
        public ComponentFeaturesSectionModelDeserialize ItemFeatures { get; set; }
        public ComponentExtraLinkSectionModelDeserialize ItemExtraLink { get; set; } 
    }

    public class IndexOxygenViewModelSerialize
    {     
        const int viewCod = 3020;

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
   
        // Component
        private readonly IComponentActivityAppService _componentActivity;
        private readonly IComponentSkillAppService _componentSkill;
        private readonly IComponentPortofolioAppService _componentPortfolio;
        private readonly IComponentTeamAppService _componentTeam;
        private readonly IComponentPricingAppService _componentPricing;
        private readonly IComponentPostAppService _componentPost;
        private readonly IComponentSocialNetworkAppService _componentSocialNetwork;
        private readonly IComponentFeaturesAppService _componentFeatures;
        private readonly IComponentExtraLinkAppService _componentExtraLink;

        // Css
        public List<string> CssFile { get; private set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; private set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; private set; }               

        // Content
        public List<string> ImagensForm{ get; private set; }
        public List<string> ImagensLogo { get; private set; }
        public List<ButtonModels> Buttons { get; private set; }
        public List<TextModels> Textos { get; private set; }

        // Component     
        public ComponentActivitySectionModelSerialize ItemActivity { get; private set; }
        public ComponentSkillSectionModelSerialize ItemSkill { get; private set; }
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }
        public ComponentTeamSectionModelSerialize ItemTeam { get; private set; }
        public ComponentPricingSectionModelSerialize ItemPricing { get; private set; }
        public ComponentPostSectionModelSerialize ItemPost { get; private set; }
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; }
        public ComponentFeaturesSectionModelSerialize ItemFeatures { get; private set; }
        public ComponentExtraLinkSectionModelSerialize ItemExtraLink { get; private set; }        
              
        // Ctor
        public IndexOxygenViewModelSerialize(

            // Admin
            IAdminImageGalleryAppService adminImageGallery,
            IAdminTemplateAppService adminTemplate,
            IAdminViewDataAppService adminViewData,

            // Config
            IConfigUserViewItemAppService configUserViewItem,
                   
            // User
            IUserImageGalleryAppService userImageGallery,
            IUserMenuViewAppService userMenu,            
            IUserRegisterProfileAppService userRegisterProfile,

            // Content
            IContentTextAppService contentText,
            IContentButtonAppService contentButton,

            // Component
            IComponentActivityAppService componentActivity,
            IComponentSkillAppService componentSkill,
            IComponentPortofolioAppService componentPortfolio,
            IComponentTeamAppService componentTeam,
            IComponentPricingAppService componentPricing,
            IComponentPostAppService componentPost,
            IComponentSocialNetworkAppService componentSocialNetwork,
            IComponentFeaturesAppService componentFeatures,
            IComponentExtraLinkAppService componentExtraLink                
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
            _userMenuView = userMenu;
            _userRegisterProfile = userRegisterProfile;

            // Content            
            _contentButton = contentButton;
            _contentText = contentText;

            // Component
            _componentActivity = componentActivity;
            _componentSkill = componentSkill;
            _componentPortfolio = componentPortfolio;
            _componentTeam = componentTeam;
            _componentPricing = componentPricing;
            _componentPost = componentPost;
            _componentSocialNetwork = componentSocialNetwork;
            _componentFeatures = componentFeatures;
            _componentExtraLink = componentExtraLink;                       
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

            //Content
            this.Buttons = new ContentButtonSectionModel(siteNumber, _contentButton, viewData).ListButton;
            this.Textos = new ContentTextSectionModel(siteNumber, _contentText, viewData).ListText;

            // Components 
            this.ItemActivity = new ComponentActivitySectionModelSerialize(siteNumber, _componentActivity, viewItens);     
            this.ItemSkill = new ComponentSkillSectionModelSerialize(siteNumber, _componentSkill, viewItens);
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);
            this.ItemTeam = new ComponentTeamSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentTeam, viewItens);
            this.ItemPricing = new ComponentPricingSectionModelSerialize(siteNumber, _componentPricing, viewItens);
            this.ItemPost = new ComponentPostSectionModelSerialize(siteNumber, _componentPost, viewItens);
            this.ItemSocialNetwork = new ComponentSocialNetworkSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentSocialNetwork, viewItens);
            this.ItemFeatures = new ComponentFeaturesSectionModelSerialize(siteNumber, _componentFeatures, viewItens);
            this.ItemExtraLink = new ComponentExtraLinkSectionModelSerialize(siteNumber, _componentExtraLink, viewItens);
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