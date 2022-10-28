using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.Mvc.Serialization.Content;
using Ishopping.Mvc.Serialization.User;
using Ishopping.MVC.SectionModels.ComponentDeserialize;
using Ishopping.MVC.SectionModels.ComponentSerialize;
using Ishopping.SectionModels.Content;
using Ishopping.SectionModels.User;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ishopping.ViewModels.TemplateProfessional
{
    public class IndexTechgutViewModelDeserialize
    {
        // Css
        public List<string> CssFile { get; set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; set; }

        // Conteudo
        public List<string> ImagensForm { get; set; }
        public List<string> ImagensLogo { get; set; }
        public List<ButtonModels> Buttons { get; set; }
        public List<TextModels> Textos { get; set; }
        public IEnumerable<ContentSliderSerialization> ContentSlider { get; set; }

        // Componentes    
        public ComponentThumbnailSectionModelDeserialize ItemThumbnail { get; set; }
        public ComponentPresentationSectionModelDeserialize ItemPresentation { get; set; }
        public ComponentActivitySectionModelDeserialize ItemActivity { get; set; }
        public ComponentPortofolioSectionModelDeserialize ItemPortofolio { get; set; }
        public ComponentTeamSectionModelDeserialize ItemTeam { get; set; }
        public ComponentClientSectionModelDeserialize ItemClient { get; set; }
        public ComponentPostSectionModelDeserialize ItemPost { get; set; }
        public ComponentSocialNetworkSectionModelDeserialize ItemSocialNetwork { get; set; }
        public ComponentFeaturesSectionModelDeserialize ItemFeatures { get; set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; set; }    
    }

    public class IndexTechgutViewModelSerialize
    {
        const int viewCod = 4020;      

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
        private readonly IContentSliderAppService _contentSlider;

        // Component
        private readonly IComponentThumbnailAppService _componentThumbnail;
        private readonly IComponentPresentationAppService _componentPresentation; 
        private readonly IComponentActivityAppService _componentActivity;   
        private readonly IComponentPortofolioAppService _componentPortfolio;
        private readonly IComponentTeamAppService _componentTeam;
        private readonly IComponentClientAppService _componentClient; 
        private readonly IComponentPostAppService _componentPost;
        private readonly IComponentSocialNetworkAppService _componentSocialNetwork;
        private readonly IComponentFeaturesAppService _componentFeatures;

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
        public IEnumerable<ContentSliderSerialization> ContentSlider { get; private set; }

        // Component   
        public ComponentThumbnailSectionModelSerialize ItemThumbnail { get; private set; }  
        public ComponentPresentationSectionModelSerialize ItemPresentation { get; private set; }
        public ComponentActivitySectionModelSerialize ItemActivity { get; private set; }
        public ComponentPortofolioSectionModelSerialize ItemPortofolio { get; private set; }
        public ComponentTeamSectionModelSerialize ItemTeam { get; private set; }
        public ComponentClientSectionModelSerialize ItemClient { get; private set; }
        public ComponentPostSectionModelSerialize ItemPost { get; private set; }
        public ComponentSocialNetworkSectionModelSerialize ItemSocialNetwork { get; private set; }
        public ComponentFeaturesSectionModelSerialize ItemFeatures { get; private set; }
        

        // Ctor 
        public IndexTechgutViewModelSerialize(

            // Admin
            IAdminImageGalleryAppService adminImageGallery, 
            IAdminTemplateAppService adminTemplate,
            IAdminViewDataAppService adminViewData,
                                
            // Config
            IConfigUserViewItemAppService configUserViewItem,

            // User
            IUserMenuViewAppService userMenuView,
            IUserRegisterProfileAppService userRegisterProfile,

            // Component
            IComponentThumbnailAppService componentThumbnail,
            IComponentPresentationAppService componentPresentation,
            IComponentActivityAppService componentActivity,  
            IComponentPortofolioAppService componentPortfolio,
            IComponentTeamAppService componentTeam,
            IComponentClientAppService componentClient,
            IComponentPostAppService componentPost,
            IComponentSocialNetworkAppService componentSocialNetwork,
            IComponentFeaturesAppService componentFeatures,

            // Content
            IContentButtonAppService contentButton,
            IContentTextAppService contentText,
            IContentSliderAppService contentSlider,

            // User
            IUserImageGalleryAppService userImageGallery
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

            // Component
            _componentThumbnail = componentThumbnail;      
            _componentPresentation = componentPresentation;
            _componentActivity = componentActivity;    
            _componentPortfolio = componentPortfolio;
            _componentTeam = componentTeam;
            _componentClient = componentClient;
            _componentPost = componentPost;
            _componentSocialNetwork = componentSocialNetwork;
            _componentFeatures = componentFeatures;

            // Content
            _contentButton = contentButton;
            _contentText = contentText;
            _contentSlider = contentSlider;                                             
        }      
   
        public void ExecuteViewModel(int siteNumber)
        {
            var viewData = _adminViewData.GetByViewCod(viewCod);
            var viewItens = _configUserViewItem.GetAllBySiteNumber(siteNumber);
            var contentSliderViewModel = _contentSlider.GetAllBySiteNumber(siteNumber).ToList();

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
            this.ContentSlider = Mapper.Map<IEnumerable<ContentSlider>, IEnumerable<ContentSliderSerialization>>(contentSliderViewModel);

            // Components
            this.ItemThumbnail = new ComponentThumbnailSectionModelSerialize(siteNumber, _componentThumbnail, viewItens);
            this.ItemPresentation = new ComponentPresentationSectionModelSerialize(siteNumber, _componentPresentation, viewItens);
            this.ItemActivity = new ComponentActivitySectionModelSerialize(siteNumber, _componentActivity, viewItens);
            this.ItemPortofolio = new ComponentPortofolioSectionModelSerialize(siteNumber, _componentPortfolio, viewItens);
            this.ItemTeam = new ComponentTeamSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentTeam, viewItens);
            this.ItemClient = new ComponentClientSectionModelSerialize(siteNumber, _componentClient, viewItens);
            this.ItemPost = new ComponentPostSectionModelSerialize(siteNumber, _componentPost, viewItens);
            this.ItemSocialNetwork = new ComponentSocialNetworkSectionModelSerialize(siteNumber, userRegisterProfile.TemplateCod, _componentSocialNetwork, viewItens);
            this.ItemFeatures = new ComponentFeaturesSectionModelSerialize(siteNumber, _componentFeatures, viewItens);                                           
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