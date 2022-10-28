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
    public class IndexHimuViewModelDeserialize
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
        public ComponentClientSectionModelDeserialize ItemClient { get; set; }//      
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }//
        public ComponentPostSectionModelDeserialize ItemPost { get; set; }//
        public ComponentPresentationSectionModelDeserialize ItemPresentation { get; set; }//       
        public ComponentSkillSectionModelDeserialize ItemSkill { get; set; }//
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }// 
        public ComponentTeamSectionModelDeserialize ItemTeam { get; set; }//     
    }

    public class IndexHimuViewModelSerialize
    {
        const int viewCod = 3040;

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
        private readonly IComponentClientAppService _componentClient;   
        private readonly IComponentPortofolioAppService _componentPortfolio;
        private readonly IComponentPostAppService _componentPost;
        private readonly IComponentPresentationAppService _componentPresentation;     
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

        // Component
        public ComponentActivitySectionModelSerialize ItemActivity { get; private set; }  
        public ComponentClientSectionModelSerialize ItemClient { get; private set; }    
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }
        public ComponentPostSectionModelSerialize ItemPost { get; private set; }
        public ComponentPresentationSectionModelSerialize ItemPresentation { get; private set; }   
        public ComponentSkillSectionModelSerialize ItemSkill { get; private set; }
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; }       
        public ComponentTeamSectionModelSerialize ItemTeam { get; private set; }   

        // Ctor
        public IndexHimuViewModelSerialize(

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
            IComponentClientAppService componentClient,           
            IComponentPortofolioAppService componentPortfolio,
            IComponentPostAppService componentPost,
            IComponentPresentationAppService componentPresentation,          
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

            // Component
            _componentActivity = componentActivity;           
            _componentClient = componentClient;       
            _componentPortfolio = componentPortfolio;
            _componentPost = componentPost;
            _componentPresentation = componentPresentation;           
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

            // Components
            this.ItemActivity = new ComponentActivitySectionModelSerialize(siteNumber, _componentActivity, viewItens);         
            this.ItemClient = new ComponentClientSectionModelSerialize(siteNumber, _componentClient, viewItens);
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);
            this.ItemPost = new ComponentPostSectionModelSerialize(siteNumber, _componentPost, viewItens);
            this.ItemPresentation = new ComponentPresentationSectionModelSerialize(siteNumber, _componentPresentation, viewItens);          
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