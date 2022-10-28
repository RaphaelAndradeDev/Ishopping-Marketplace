using Ishopping.Common.Resources;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ishopping.Domain.Services
{
    public class AccountManagerService : IAccountManagerService
    {
        private readonly IAdminTemplateRepository _adminTemplate;
        private readonly IAdminViewDataService _adminViewData;
        private readonly IAdminViewItemRepository _adminViewItem;
        private readonly IAdminFinancialPlanService _adminFinancialPlan;        
        private readonly IUserRegisterProfileRepository _userRegisterProfile;
        private readonly IUserSerializeViewDataRepository _userSerializeViewData;
        private readonly IConfigUserAppearanceRepository _configUserAppearance;
        private readonly IConfigUserViewRepository _configUserView;
        private readonly IConfigUserViewItemService _configUserViewItem;
        private readonly IUserMenuRepository _userMenu;
        private readonly IUserMenuViewService _userMenuView;
        private readonly IUserMenuViewItemService _userMenuViewItem;
        private readonly IConfigUserMaintenanceService _configUserMaintenance;
        private readonly IUserFinancialRepository _userFinancial;
        private readonly IContentSliderRepository _contentSlider;
        private readonly IConfigUserStyleClassRepository _configUserStyleClass;
        private readonly IUserImageGalleryRepository _userImageGallery;
        private readonly IDeleteContentRepository _deleteContent;
        private readonly IDeleteComponentRepository _deleteComponent;
        private readonly IEntityOptionRepository _entityOption;
        private readonly IAppViewService _appViewService;
    
        public AccountManagerService(
            IAdminTemplateRepository adminTemplate,
            IAdminViewDataService adminViewData,
            IAdminViewItemRepository adminViewItem,
            IAdminFinancialPlanService adminFinancialPlan,
            IUserRegisterProfileRepository userRegisterProfile,
            IUserSerializeViewDataRepository userSerializeViewData,
            IConfigUserAppearanceRepository configUserAppearance,
            IConfigUserViewRepository configUserView,
            IConfigUserViewItemService configUserViewItem,
            IUserMenuRepository userMenu,
            IUserMenuViewService userMenuView,
            IUserMenuViewItemService userMenuViewItem,
            IConfigUserMaintenanceService configUserMaintenance,
            IUserFinancialRepository userFinancial,
            IContentSliderRepository contentSlider,
            IConfigUserStyleClassRepository configUserStyleClass,
            IUserImageGalleryRepository userImageGallery,
            IDeleteContentRepository deleteContent,
            IDeleteComponentRepository deleteComponent,
            IEntityOptionRepository entityOption,
            IAppViewService appViewService
            )
        {
            _adminTemplate = adminTemplate;
            _adminViewData = adminViewData;
            _adminViewItem = adminViewItem;
            _adminFinancialPlan = adminFinancialPlan;
            _userRegisterProfile = userRegisterProfile;
            _userSerializeViewData = userSerializeViewData;
            _configUserAppearance = configUserAppearance;
            _configUserView = configUserView;
            _configUserViewItem = configUserViewItem;
            _userMenu = userMenu;
            _userMenuView = userMenuView;
            _userMenuViewItem = userMenuViewItem;
            _configUserMaintenance = configUserMaintenance;
            _userFinancial = userFinancial;
            _contentSlider = contentSlider;
            _configUserStyleClass = configUserStyleClass;
            _userImageGallery = userImageGallery;
            _deleteContent = deleteContent;
            _deleteComponent = deleteComponent;
            _entityOption = entityOption;
            _appViewService = appViewService;
        }

        public void AddProfile(UserRegisterProfile userRegisterProfile)
        {             
                            
            ConfigUserStyleClass styleClass = new ConfigUserStyleClass();
            styleClass.IdUser = userRegisterProfile.IdUser;
            styleClass.SiteNumber = userRegisterProfile.SiteNumber;
            styleClass.ClassName = "SemEstilo";            

            _userRegisterProfile.Add(userRegisterProfile);            
                      
            _configUserStyleClass.Add(styleClass);
            _configUserStyleClass.Dispose();           
        } 

        public void AddProfileExtension(UserRegisterProfile userRegisterProfile, int? oldTemplateCod, string[] cssPath)
        {          
            var listAdminViewData = _adminViewData.GetAllByTemplateCod(userRegisterProfile.TemplateCod).ToList();                 
               
            // Set serialize
            userRegisterProfile.SetSerialize(true);

            // Add Maintenance
            AddConfigUserMaintenance(listAdminViewData, userRegisterProfile);
            
            // Add appearance  
           AddAppearance(userRegisterProfile, cssPath);                                       
           
            // Add Content Option
            AddContentOption(listAdminViewData, userRegisterProfile.IdUser);

            // Add Component Option
            AddComponentOption(oldTemplateCod, userRegisterProfile.TemplateCod, userRegisterProfile.IdUser);

            // Add Slider
            AddSlider(userRegisterProfile, listAdminViewData);

            // Add Menu
            AddUserMenu(userRegisterProfile, listAdminViewData);            
        }         

        public void SetApplication(UserRegisterProfile userRegisterProfile)
        {
            var adminViewData = _adminViewData.GetAllByTemplateCod(userRegisterProfile.TemplateCod).ToList();
            SetApplicationMenu(userRegisterProfile, adminViewData);
            SetApplicationControllers(userRegisterProfile, adminViewData);
        }

        public void ProfileViewUpdate(string userId, string id, int viewCod, bool ativo, string textMenu)
        {

            MenuUpdate(userId, viewCod, ativo, textMenu);
            ViewUpdate(id, userId, ativo, textMenu);

        }

        public void ProfileViewItemUpdate(string userId, string configUserViewItemId, bool ativo, string textMenu, string textView)
        {
            var _id = Guid.Parse(configUserViewItemId);
            var configUserViewItem = _configUserViewItem.GetBy(_id, userId);
            ViewItemUpdate(configUserViewItem, ativo, textMenu, textView);
            MenuItemUpdate(userId, configUserViewItem, ativo, textMenu);
            UserRegisterAppMenuUpdate(userId, configUserViewItem, ativo);
        }    
            
        public void DeleteProfileExtension(string userId, int newTemplateCod)
        {
            var userRegisterProfile = _userRegisterProfile.GetByUserId(userId);

            // Delete User          
            DeleteUser(userRegisterProfile);        

            // Delete Config
            DeleteConfig(userId);

            // Delete Appearance
            DeleteAppearance(userId);

            // Delete Content  
            DeleteContent(userId);            

            // Delete Component            
            var listImgType = DeleteComponent(userRegisterProfile, newTemplateCod);

            // Delete Images
            DeleteImages(userId, listImgType.ToList());
        }
        

        // Private Methods
        private IEnumerable<string> GetCssColor(string[] cssPath)
        {
            List<string> colors = new List<string>();
            string pattern = @"#([A-Fa-f0-9]{3}){1,2}|(rgba|hsla)\(\d{1,3}%?(,\s?\d{1,3}%?){2},\s?(1|0?\.\d+)\)|(rgb|hsl)\(\d{1,3}%?(,\s?\d{1,3}%?\)){2}";

            foreach (var filePath in cssPath)
            {
                var content = string.Empty;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }
                foreach (Match match in Regex.Matches(content, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                    colors.Add(match.Value.ToLower());
            }
            return colors.Distinct();
        }

        private void AddConfigUserMaintenance(IEnumerable<AdminViewData> listAdminViewData, UserRegisterProfile userRegisterProfile)
        {
            var controller = GetControllerName(listAdminViewData, userRegisterProfile.ViewStart);
            var appView = GetAppViewByType(1);

            ConfigUserMaintenance maintenance = new ConfigUserMaintenance(
                userRegisterProfile.IdUser, userRegisterProfile.SiteNumber, true, controller, appView.Name, appView.PartialView, Messages.ManutencaoTitle,
                DateTime.Now.AddMonths(1), Messages.ManutencaoText + " " + userRegisterProfile.Empresa + ".");

            _configUserMaintenance.Add(maintenance);
            _configUserMaintenance.Dispose();
        }

        private void AddContentOption(List<AdminViewData> listAdminViewData, string userId)
        {
            if (listAdminViewData.Any(x => x.NumBtn > 0)) { _entityOption.AddEntityOption( 11, userId); }         
            if (listAdminViewData.Any(x => x.ListList > 0)) { _entityOption.AddEntityOption(13, userId); }
            if (listAdminViewData.Any(x => x.ListText != "")) { _entityOption.AddEntityOption(14, userId); }      
        }

        private void AddComponentOption(int? oldTemplateCod, int newTemplateCod, string userId)
        {
            if(oldTemplateCod.HasValue)
            {
                var listEntityOption = GetViewItemNewExceptOld(oldTemplateCod.Value, newTemplateCod);
                _entityOption.AddEntityOption(listEntityOption, userId);
            }
            else
            {
                var listEntityOption = _adminViewItem.GetAllViewItemCod(newTemplateCod);
                _entityOption.AddEntityOption(listEntityOption, userId);
            }                       
        }

        private string GetControllerName(IEnumerable<AdminViewData> listAdminViewData, int viewCod)
        {
            return listAdminViewData.First(x => x.ViewCod == viewCod).Controller;
        }

        private AppView GetAppViewByType(int type)
        {
            return _appViewService.GetAllByType(type).First();
        }

        private string ConfigLink(int siteNumber, string link)
        {
            if (link == "#isBlog")
                return link = "/AppView/Blog?siteNumber=" + siteNumber;
            return link;
        }

        private void SetApplicationMenu(UserRegisterProfile userRegisterProfile, List<AdminViewData> adminViewData)
        {
            string itens = "";

            // Menu               
            itens = adminViewData.First(x => x.ViewCod == userRegisterProfile.ViewStart).Controller + ",";
            itens += userRegisterProfile.SiteNumber + ",";

            // Content  
            if (adminViewData.Any(x => x.NumBtn > 0)) { itens += "ct_11,"; }
            if (adminViewData.Any(x => x.ListVectorIcon != "")) { itens += "ct_12,"; }
            if (adminViewData.Any(x => x.ListList > 0)) { itens += "ct_13,"; }
            if (adminViewData.Any(x => x.ListText != "")) { itens += "ct_14,"; }
            if (adminViewData.Any(x => x.NumVideo > 0)) { itens += "ct_15,"; }
            if (adminViewData.Any(x => x.AdminSlider.Count() > 0)) { itens += "ct_16,"; }

            // Config
            if (adminViewData.Exists(x => x.AdminSlider.Any())) { itens += "cf_11,"; }

            // Image gallery for content
            if (adminViewData.Any(x => x.ListImage > 0)) { itens += "img_11,"; }
            if (adminViewData.Any(x => x.ListIconPng > 0)) { itens += "img_12,"; }
            if (adminViewData.Any(x => x.ListLogo > 0)) { itens += "img_13,"; }
            if (adminViewData.Any(x => x.AdminSlider.Count() > 0)) { itens += "img_14,"; }

            // Components
            var components = _configUserViewItem.GetAllAdminViewItemCod(userRegisterProfile.IdUser);

            foreach (var item in components)
            {
                string component = item.ToString().Trim();
                itens += "cp_" + component.ToLower() + ",";
                itens += "img_" + component.ToLower() + ",";
            }

            userRegisterProfile.ChangeAppMenu(itens.Remove(itens.Length - 1));
        }

        private void SetApplicationControllers(UserRegisterProfile userRegisterProfile, List<AdminViewData> adminViewData)
        {
            string controller = string.Empty;
            foreach (var item in adminViewData)
            {
                controller += item.Controller.ToLower() + ",";
            }
            userRegisterProfile.SetController(controller.Remove(controller.Length - 1));
        }

        private void AddSlider(UserRegisterProfile userRegisterProfile, List<AdminViewData> listAdminViewData)
        {
            List<ContentSlider> listContentSlider = new List<ContentSlider>();

            foreach (var adminViewData in listAdminViewData)
            {
                if (adminViewData.ExSlider && adminViewData.ViewDefault)
                {
                    foreach (var viewSlider in adminViewData.AdminSlider)
                    {
                        var contentSlider = new ContentSlider();
                        contentSlider.IdUser = userRegisterProfile.IdUser;
                        contentSlider.SiteNumber = userRegisterProfile.SiteNumber;
                        contentSlider.ViewCod = viewSlider.AdminViewData.ViewCod;
                        contentSlider.Position = viewSlider.Position;
                        contentSlider.SliderType = viewSlider.SliderType;
                        contentSlider.SliderName = viewSlider.SliderName;
                        contentSlider.SliderClass = viewSlider.SliderClass;
                        contentSlider.PartialView = viewSlider.PartialView;
                        contentSlider.ClassTarget = viewSlider.ClassTarget;
                        contentSlider.Incoming = viewSlider.Incoming;
                        contentSlider.Outgoing = viewSlider.Outgoing;
                        contentSlider.DataStart = viewSlider.DataStart;
                        contentSlider.DataEnd = viewSlider.DataEnd;
                        contentSlider.DataX = viewSlider.DataX;
                        contentSlider.DataY = viewSlider.DataY;
                        contentSlider.DataHoffset = viewSlider.DataHoffset;
                        contentSlider.DataVoffset = viewSlider.DataVoffset;
                        contentSlider.DataSpeed = viewSlider.DataSpeed;
                        contentSlider.DataEndSpeed = viewSlider.DataEndSpeed;
                        contentSlider.DataEasing = viewSlider.DataEasing;
                        contentSlider.DataEndEasing = viewSlider.DataEndEasing;
                        contentSlider.DataSplitin = viewSlider.DataSplitin;
                        contentSlider.DataSplitout = viewSlider.DataSplitout;
                        contentSlider.DataElementdelay = viewSlider.DataElementdelay;
                        contentSlider.DataEndelementdelay = viewSlider.DataEndelementdelay;
                        contentSlider.DataImgWidth = viewSlider.DataImgWidth;
                        contentSlider.DataImgHeight = viewSlider.DataImgHeight;
                        contentSlider.DataImgZindex = viewSlider.DataImgZindex;
                        contentSlider.Caption = viewSlider.Caption;
                        contentSlider.Text = viewSlider.Text;
                        contentSlider.Url = viewSlider.Url;
                        contentSlider.ImageUrl = "~/Content/uploads/" + contentSlider.ViewCod + "/" + viewSlider.ImageFileName;
                        listContentSlider.Add(contentSlider);
                    }
                }
            }

            _contentSlider.AddRanger(listContentSlider);
            _contentSlider.Dispose();
        }

        private void AddAppearance(UserRegisterProfile userRegisterProfile, string[] cssPath)
        {
            List<ConfigUserStyleColor> ListConfigUserStyleColor = new List<ConfigUserStyleColor>();

            var cssColor = GetCssColor(cssPath);
            foreach (var item in cssColor)
            {
                ListConfigUserStyleColor.Add(new ConfigUserStyleColor { DefaultColor = item, UserColor = item });
            }
            var configUserStyleColor = new List<ConfigUserStyleColor>(ListConfigUserStyleColor);
            var configUserAppearance = new ConfigUserAppearance(userRegisterProfile.IdUser, userRegisterProfile.SiteNumber, configUserStyleColor, "Style_1");

            _configUserAppearance.Add(configUserAppearance);
            _configUserAppearance.Dispose();
        }

        private void AddUserMenu(UserRegisterProfile userRegisterProfile, List<AdminViewData> listAdminViewData)
        {
            List<UserMenuView> listUserMenuView = new List<UserMenuView>();
            List<UserMenuViewItem> listUserMenuViewItem = new List<UserMenuViewItem>();

            List<ConfigUserView> listConfigUserView = new List<ConfigUserView>();
            List<ConfigUserViewItem> listConfigUserViewItem = new List<ConfigUserViewItem>();                 

            UserMenu userMenu = new UserMenu(userRegisterProfile.IdUser, userRegisterProfile.SiteNumber, false, false);          

            foreach (var adminViewData in listAdminViewData)
            {
                ConfigUserView configUserView = new ConfigUserView(userRegisterProfile.IdUser, userRegisterProfile.SiteNumber, adminViewData.Id, true, adminViewData.TextMenu);                            

                // adiciona no menu a view padrão               
                if (adminViewData.ViewCod == userRegisterProfile.ViewStart)
                {
                    UserMenuView userMenuView = new UserMenuView(userMenu, adminViewData.TextMenu, adminViewData.Action, adminViewData.Controller, adminViewData.ViewName, adminViewData.ViewCod, adminViewData.ViewTipo, adminViewData.OnMenu, adminViewData.ViewLink, adminViewData.Active, adminViewData.ClassActive);

                    foreach (var adminViewItem in adminViewData.AdminViewItem)
                    {
                        ConfigUserViewItem configUserViewItem = new ConfigUserViewItem(userRegisterProfile.IdUser, userRegisterProfile.SiteNumber, adminViewItem.Id, configUserView.Id, true, adminViewItem.TextMenu, adminViewItem.TextView, "SemEstilo", "SubTitulo", "SemEstilo");                                             

                        if (adminViewItem.Active)
                        {
                            UserMenuViewItem userMenuViewItem = new UserMenuViewItem(userMenuView, adminViewItem.TextMenu, adminViewItem.OnMenu, true, ConfigLink(userRegisterProfile.SiteNumber, adminViewItem.Link), adminViewItem.ViewTipo);
                            listUserMenuViewItem.Add(userMenuViewItem);
                        }
                        listConfigUserViewItem.Add(configUserViewItem);
                    }
                    userMenuView.AddListUserMenuViewItem(listUserMenuViewItem);
                    listUserMenuView.Add(userMenuView);
                }

                configUserView.AddListConfigUserViewItem(listConfigUserViewItem);
                listConfigUserView.Add(configUserView);                                            
            }

           userMenu.AddListUserMenuView(listUserMenuView);

           _userMenu.Add(userMenu);
           _userMenu.Dispose();

           _configUserView.AddRanger(listConfigUserView);
           _configUserView.Dispose();
        }

        private void ViewUpdate(string id, string userId, bool ativo, string textMenu)
        {
            var configUserView = _configUserView.GetById(id, userId);
            configUserView.Change(ativo, textMenu);
            _configUserView.Update(configUserView);
        }

        private void MenuUpdate(string userId, int viewCod, bool ativo, string textMenu)
        {
            var userMenu = _userMenu.GetByUserId(userId);
            var viewData = _adminViewData.GetByViewCod(viewCod);
            var userMenuView = userMenu.UserMenuView.FirstOrDefault(x => x.ViewCod == viewCod);
            if (userMenuView != null)
            {
                userMenuView.Change(textMenu, ativo);
            }
            else
            {
                var userMenuViewOld = userMenu.UserMenuView.FirstOrDefault(x => x.ViewTipo == viewData.ViewTipo);
                _userMenuView.Remove(userMenuViewOld);

                userMenuView = new UserMenuView(userMenu, textMenu, viewData.Action, viewData.Controller, viewData.ViewName, viewData.ViewCod, viewData.ViewTipo, viewData.OnMenu, viewData.ViewLink, ativo);

                var listUserMenuViewItem = new List<UserMenuViewItem>();
                foreach (var item in viewData.AdminViewItem)
                {
                    var itensMenu = new UserMenuViewItem(userMenuView, item.TextMenu, item.OnMenu, ativo, item.Link, item.ViewTipo);
                    listUserMenuViewItem.Add(itensMenu);
                }
                userMenuView.AddListUserMenuViewItem(listUserMenuViewItem);
                userMenu.AddUserMenuView(userMenuView);
            }
            _userMenu.Update(userMenu);
        }

        private void ViewItemUpdate(ConfigUserViewItem configUserViewItem, bool ativo, string textMenu, string textView)
        {
            configUserViewItem.Change(ativo, textMenu, textView);
            _configUserViewItem.Update(configUserViewItem);            
        }

        private void MenuItemUpdate(string userId, ConfigUserViewItem configUserViewItem, bool ativo, string textMenu)
        {        
            int viewCod = configUserViewItem.ConfigUserView.AdminViewData.ViewCod;
            string itemType = configUserViewItem.AdminViewItem.ViewTipo;
            var userMenuViewItem = _userMenuViewItem.GetBy(userId, viewCod, itemType);
            userMenuViewItem.Change(ativo, textMenu);
            _userMenuViewItem.Update(userMenuViewItem);
        }

        private void UserRegisterAppMenuUpdate(string userId, ConfigUserViewItem configUserViewItem, bool ativo)
        {
            var profile = _userRegisterProfile.GetByUserId(userId);
            int viewTypeCod = configUserViewItem.AdminViewItem.ViewTypeCod;

            string viewTypeCp = "cp_" + viewTypeCod.ToString();
            string viewTypeImg = "img_" + viewTypeCod.ToString();

            string[] itens = profile.AppMenu.Split(',');
            bool existItem = Array.Exists(itens, x => x.StartsWith(viewTypeCp));

            if (ativo && !existItem)
            {
                profile.ChangeAppMenu(profile.AppMenu + "," + viewTypeCp + "," + viewTypeImg);
            }

            if (!ativo && existItem)
            {
                itens = itens.Except(new string[] { viewTypeCp, viewTypeImg }).ToArray();
                profile.ChangeAppMenu(string.Join(",", itens));
            }

            _userRegisterProfile.Update(profile);
        }

        private void DeleteUser(UserRegisterProfile userRegisterProfile)
        {
            var userMenu = _userMenu.GetByUserId(userRegisterProfile.IdUser);
            if (userMenu != null)
                _userMenu.Remove(userMenu);
            _userSerializeViewData.RemoveAll(userRegisterProfile.SiteNumber);
        }

        private void DeleteConfig(string userId)
        {
            _configUserView.DeleteAll(userId);
            _configUserMaintenance.RemoveAll(userId);
        }

        private void DeleteAppearance(string userId)
        {
            var appearance = _configUserAppearance.GetByUserId(userId);
            if (appearance != null)
                _configUserAppearance.Remove(appearance);
        }

        private void DeleteContent(string userId)
        {
            _contentSlider.DeleteAll(userId);
            _deleteContent.DeleteContent(userId);
        }

        private IEnumerable<int> DeleteComponent(UserRegisterProfile userRegisterProfile, int newTemplateCod)
        {        
            var adminViewItem = GetViewItemOldExceptNew(userRegisterProfile.TemplateCod, newTemplateCod);
            return _deleteComponent.DeleteComponent(userRegisterProfile.IdUser, adminViewItem);
        }

        private IEnumerable<int> GetViewItemOldExceptNew(int oldTemplateCod, int newTemplateCod)
        {
            // retorna itens que não estão no novo template
            var oldAdminViewItem = _adminViewItem.GetAllViewItemCod(oldTemplateCod);
            var newAdminViewItem = _adminViewItem.GetAllViewItemCod(newTemplateCod);
            return oldAdminViewItem.Except(newAdminViewItem);
        }

        private IEnumerable<int> GetViewItemNewExceptOld(int oldTemplateCod, int newTemplateCod)
        {
            // retorna itens que já estão no novo template
            var oldAdminViewItem = _adminViewItem.GetAllViewItemCod(oldTemplateCod);
            var newAdminViewItem = _adminViewItem.GetAllViewItemCod(newTemplateCod);
            return newAdminViewItem.Except(oldAdminViewItem);
        }

        private IEnumerable<int> GetViewItemOldEqualsNew(int oldTemplateCod, int newTemplateCod)
        {
            // retorna itens que são iguais aos dois templates
            var oldAdminViewItem = _adminViewItem.GetAllViewItemCod(oldTemplateCod);
            var newAdminViewItem = _adminViewItem.GetAllViewItemCod(newTemplateCod);
            var except = oldAdminViewItem.Except(newAdminViewItem);
            return oldAdminViewItem.Except(except);
        }

        private void DeleteImages(string userId, List<int> listImgType)
        {
            listImgType.Add(1); // imagens da view
            listImgType.Add(2); // imagens de icon
            listImgType.Add(3); // imagens de logo
            var userImageGallery = _userImageGallery.GetAllisContain(listImgType, userId).ToList();
            _userImageGallery.RemoveRanger(userImageGallery);
        }
    }
}
