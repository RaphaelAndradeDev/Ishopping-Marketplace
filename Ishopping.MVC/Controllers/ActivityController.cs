using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]   
    public class ActivityController : Controller
    {               
        private readonly IComponentActivityAppService _componentActivity;
        private readonly IComponentActivityOptionAppService _componentActivityOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;       

        private const string viewType = "cp_21";

        public ActivityController(                              
            IComponentActivityAppService componentActivity,
            IComponentActivityOptionAppService componentActivityOption,
            IConfigUserStyleClassAppService configUserStyleClass,      
            IUserRegisterProfileAppService userRegisterProfile)
        {                        
            _componentActivity = componentActivity;
            _componentActivityOption = componentActivityOption;
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

            ViewBag.Classe = await _componentActivityOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
                                                
            return View();
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentActivity.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       public async Task<JsonResult> GetTexto(string term, int ps = 1)
       {
            string userId = User.Identity.GetUserId();                  
            var result = await _componentActivity.SearchAsync(term, ps, userId); 
            return Json(result, JsonRequestBehavior.AllowGet);
        }          

        public async Task<JsonResult> GetResultTxt(string term, int ps = 1)
        {
            string userId = User.Identity.GetUserId();    
            var result = await _componentActivity.GetObjetoAsync(term, ps, userId);      
            return Json(result);     
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int position, string title, string stTitle, string description, string stDescription, string icon)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);                     

            try
            {
                JsonResponse json = await _componentActivity.AppUpdateAsync(id, userId, profile.SiteNumber, position, title, stTitle, description, stDescription, icon);           
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ActivityController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentActivity.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ActivityController", "Delete", profile.SiteNumber.ToString());
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