using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Ishopping.MVC;
using Ishopping.ViewModels.Option;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")] 
    public class PortfolioOptionController : Controller
    {       
        private readonly IConfigUserViewItemAppService _configUserViewItem;        
        private readonly IComponentPortfolioOptionAppService _componentPortfolioOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "cp_29";
        private const int viewCod = 29;  

        public PortfolioOptionController(        
            IConfigUserViewItemAppService configUserViewItem,           
            IComponentPortfolioOptionAppService componentPortfolioOption, 
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile)
        {          
            _configUserViewItem = configUserViewItem;            
            _componentPortfolioOption = componentPortfolioOption;
            _configUserStyleClass = configUserStyleClass;
            _userRegisterProfile = userRegisterProfile;
        }

        public async Task<ActionResult> Alter()
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType)) return HttpNotFound();

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "component";

            var optionViewModel = new PortfolioOptionViewModel();
            optionViewModel.BasicUserViewItem = await _configUserViewItem.GetBasicViewItemAsync(viewCod, userId);
            optionViewModel.ComponentPortfolioOption = await _componentPortfolioOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
                  
            return View(optionViewModel);           
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string textView, string styleTextView, string subTitleView, string styleSubTitleView,
                string title, string category, string list, string description)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {                            
                _configUserViewItem.SetConfigUserViewItemOption(textView, styleTextView, subTitleView, styleSubTitleView, viewCod, userId);
                JsonResponse json = await _componentPortfolioOption.AppUpdateAsync(category, title, description, list, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioOptionController", "Salvar", profile.SiteNumber.ToString());
                JsonError json = new JsonError(ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}