using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")] 
    public class ScopeController : Controller
    {     
        private readonly IComponentScopeAppService _componentScope;
        private readonly IComponentScopeOptionAppService _componentScopeOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "cp_39";

        public ScopeController(       
            IComponentScopeAppService componentScope, 
            IComponentScopeOptionAppService componentScopeOption,
             IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile)
        {          
            _componentScope = componentScope;
            _componentScopeOption = componentScopeOption;
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

            ViewBag.Classe = await _componentScopeOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
                        
            return View();
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentScope.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term, int ps = 1)
        {
            string userId = User.Identity.GetUserId();      
            var result = await _componentScope.SearchAsync(term, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }          

        public async Task<JsonResult> GetResultTxt(string term, int ps = 1)
        {
            string userId = User.Identity.GetUserId();      
            var result = await _componentScope.GetObjetoAsync(term, ps, userId);      
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int position, string title, string stTitle, string category, string stCategory, string description, string stDescription, string icon)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);            

            try
            {
                JsonResponse json = await _componentScope.AppUpdateAsync(id, userId, profile.SiteNumber, position, title, stTitle, category, stCategory, description, stDescription, icon);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ScopeController", "Salvar", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            } 
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(string id)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonDelete json = await _componentScope.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ScopeController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
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