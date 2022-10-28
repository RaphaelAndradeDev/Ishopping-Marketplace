using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Ishopping.MVC;
using Ishopping.ViewModels.Option;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")] 
    public class ListOptionController : Controller
    {        
        private readonly IContentListOptionAppService _contentListOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        const string viewType = "ct_13";

        public ListOptionController(       
            IContentListOptionAppService contentListOption, 
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile)
        {      
            _contentListOption = contentListOption;
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
            ViewBag.ActiveFor = "content";
      
            var listOptionViewModel = new ListOptionViewModel();
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
            listOptionViewModel.ContentListOption = await _contentListOption.GetDefaultAsync(userId);
            
            return View(listOptionViewModel);
        }      

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string list)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonResponse json = await _contentListOption.AppUpdateAsync(list, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ListOptionController", "Salvar", profile.SiteNumber.ToString());
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