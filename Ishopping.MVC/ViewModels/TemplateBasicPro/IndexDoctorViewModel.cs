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
    public class IndexDoctorViewModelDeserialize
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
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }//
        public ComponentServiceSectionModelDeserialize ItemService { get; set; }//    
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }//  
        public ComponentTeamSectionModelDeserialize ItemTeam { get; set; }//       
    }

    public class IndexDoctorViewModelSerialize
    {
        const int viewCod = 3100;

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

        private readonly IComponentPortofolioAppService _componentPortfolio;      
        private readonly IComponentServiceAppService _componentService;   
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
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }      
        public ComponentServiceSectionModelSerialize ItemService { get; private set; }   
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; } 
        public ComponentTeamSectionModelSerialize ItemTeam { get; private set; }     

        // Ctor
        public IndexDoctorViewModelSerialize(

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
            IComponentPortofolioAppService componentPortfolio,         
            IComponentServiceAppService componentService,         
            IComponentSocialNetworkAppService componentSocialNetwork,           
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
            _userMenuView = userMenuView;
            _userRegisterProfile = userRegisterProfile;

            // Content
            _contentButton = contentButton;
            _contentText = contentText;

            // Component    
            _componentPortfolio = componentPortfolio;      
            _componentService = componentService;      
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
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);         
            this.ItemService = new ComponentServiceSectionModelSerialize(siteNumber, _componentService, viewItens);
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