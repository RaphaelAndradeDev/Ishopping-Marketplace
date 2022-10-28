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

namespace Ishopping.ViewModels.TemplateProfessional
{
    public class IndexMaximaViewModelDeserialize
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
        public ComponentActivitySectionModelDeserialize ItemActivity { get; set; }//        
        public ComponentFeaturesSectionModelDeserialize ItemFeatures { get; set; }//     
        public ComponentPanelSectionModelDeserialize ItemPanel { get; set; }//
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }//
        public ComponentPostSectionModelDeserialize ItemPost { get; set; }//     
        public ComponentScopeSectionModelDeserialize ItemScope { get; set; }//       
        public ComponentSimpleProductSectionModelDeserialize ItemSimpleProduct { get; set; }//
        public ComponentSkillSectionModelDeserialize ItemSkill { get; set; }//
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }//       
        public ComponentThumbnailSectionModelDeserialize ItemThumbnail { get; set; }//
    }
    public class IndexMaximaViewModelSerialize
    {
        const int viewCod = 4060;

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
        private readonly IComponentFeaturesAppService _componentFeatures;  
        private readonly IComponentPanelAppService _componentPanel;
        private readonly IComponentPortofolioAppService _componentPortfolio;
        private readonly IComponentPostAppService _componentPost;    
        private readonly IComponentScopeAppService _componentScope;    
        private readonly IComponentSimpleProductAppService _componentSimpleProduct;
        private readonly IComponentSkillAppService _componentSkill;
        private readonly IComponentSocialNetworkAppService _componentSocialNetwork;     
        private readonly IComponentThumbnailAppService _componentThumbnail;

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

        // Component
        public ComponentActivitySectionModelSerialize ItemActivity { get; private set; }     
        public ComponentFeaturesSectionModelSerialize ItemFeatures { get; private set; }  
        public ComponentPanelSectionModelSerialize ItemPanel { get; private set; }
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }
        public ComponentPostSectionModelSerialize ItemPost { get; private set; }      
        public ComponentScopeSectionModelSerialize ItemScope { get; private set; }       
        public ComponentSimpleProductSectionModelSerialize ItemSimpleProduct { get; private set; }
        public ComponentSkillSectionModelSerialize ItemSkill { get; private set; }
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; }       
        public ComponentThumbnailSectionModelSerialize ItemThumbnail { get; private set; }

        // Ctor
        public IndexMaximaViewModelSerialize(

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

            // Component      
            IComponentActivityAppService componentActivity,           
            IComponentFeaturesAppService componentFeatures,            
            IComponentPanelAppService componentPanel,
            IComponentPortofolioAppService componentPortfolio,
            IComponentPostAppService componentPost,           
            IComponentScopeAppService componentScope,          
            IComponentSimpleProductAppService componentSimpleProduct,
            IComponentSkillAppService componentSkill,
            IComponentSocialNetworkAppService componentSocialNetwork,           
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
            _userMenuView = userMenuView;
            _userRegisterProfile = userRegisterProfile;

            // Content
            _contentButton = contentButton;
            _contentText = contentText;           

            // Component
            _componentActivity = componentActivity;      
            _componentFeatures = componentFeatures;       
            _componentPanel = componentPanel;
            _componentPortfolio = componentPortfolio;
            _componentPost = componentPost;          
            _componentScope = componentScope;   
            _componentSimpleProduct = componentSimpleProduct;
            _componentSkill = componentSkill;
            _componentSocialNetwork = componentSocialNetwork;         
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
            var userMenuView = _userMenuView.GetUserMenu(siteNumber);
            this.Menu = Mapper.Map<IEnumerable<UserMenuView>, IEnumerable<UserMenuViewSerialization>>(userMenuView);

            // Images 
            this.ImagensForm = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 1, viewCod, viewData).ListImage;        
            this.ImagensLogo = new UserImageGallerySectionModel(siteNumber, _userImageGallery, _adminImageGallery, 3, viewCod, viewData).ListImage;

            // Content                     
            this.Buttons = new ContentButtonSectionModel(siteNumber, _contentButton, viewData).ListButton;
            this.Textos = new ContentTextSectionModel(siteNumber, _contentText, viewData).ListText;      

            // Components
            this.ItemActivity = new ComponentActivitySectionModelSerialize(siteNumber, _componentActivity, viewItens);      
            this.ItemFeatures = new ComponentFeaturesSectionModelSerialize(siteNumber, _componentFeatures, viewItens);     
            this.ItemPanel = new ComponentPanelSectionModelSerialize(siteNumber, _componentPanel, viewItens);
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);
            this.ItemPost = new ComponentPostSectionModelSerialize(siteNumber, _componentPost, viewItens);          
            this.ItemScope = new ComponentScopeSectionModelSerialize(siteNumber, _componentScope, viewItens);           
            this.ItemSimpleProduct = new ComponentSimpleProductSectionModelSerialize(siteNumber, _componentSimpleProduct, viewItens);
            this.ItemSkill = new ComponentSkillSectionModelSerialize(siteNumber, _componentSkill, viewItens);
            this.ItemSocialNetwork = new ComponentSocialNetworkSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentSocialNetwork, viewItens);              
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