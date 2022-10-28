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

namespace Ishopping.ViewModels.TemplateBasic
{
    public class IndexAppPlusViewModelDeserialize
    {
        // Css
        public List<string> CssFile { get; set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; set; }

        // Content
        public List<string> ImagensForm { get; set; }
        public List<ButtonModels> Buttons { get; set; }
        public List<TextModels> Textos { get; set; }
        public List<string> Videos { get; set; }

        // Component       
        public ComponentExtraLinkSectionModelDeserialize ItemExtraLink { get; set; }//        
        public ComponentServiceSectionModelDeserialize ItemService { get; set; }//     
        public ComponentThumbnailSectionModelDeserialize ItemThumbnail { get; set; }//
    }
    public class IndexAppPlusViewModelSerialize
    {
        const int viewCod = 2050;

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
        private readonly IComponentExtraLinkAppService _componentExtraLink;     
        private readonly IComponentServiceAppService _componentService;
        private readonly IComponentThumbnailAppService _componentThumbnail;

        // Css
        public List<string> CssFile { get; private set; }

        // Profile
        public UserRegisterProfileSerialization Profile { get; private set; }

        // Menu        
        public IEnumerable<UserMenuViewSerialization> Menu { get; private set; }

        // Content
        public List<string> ImagensForm { get; private set; }
        public List<ButtonModels> Buttons { get; private set; }
        public List<TextModels> Textos { get; private set; }
        public List<string> Videos { get; private set; }

        // Component
        public ComponentExtraLinkSectionModelSerialize ItemExtraLink { get; private set; }       
        public ComponentServiceSectionModelSerialize ItemService { get; private set; }    
        public ComponentThumbnailSectionModelSerialize ItemThumbnail { get; private set; }

        // Ctor
        public IndexAppPlusViewModelSerialize(

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
            IComponentExtraLinkAppService componentExtraLink,        
            IComponentServiceAppService componentService,        
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
            _contentVideo = contentVideo;

            // Component      
            _componentExtraLink = componentExtraLink;         
            _componentService = componentService;        
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

            // Content                     
            this.Buttons = new ContentButtonSectionModel(siteNumber, _contentButton, viewData).ListButton;
            this.Textos = new ContentTextSectionModel(siteNumber, _contentText, viewData).ListText;
            this.Videos = new ContentVideoSectionModel(siteNumber, _contentVideo, viewData).ListVideo;

            // Components     
            this.ItemExtraLink = new ComponentExtraLinkSectionModelSerialize(siteNumber, _componentExtraLink, viewItens);       
            this.ItemService = new ComponentServiceSectionModelSerialize(siteNumber, _componentService, viewItens);
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