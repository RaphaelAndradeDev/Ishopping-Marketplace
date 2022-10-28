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
    public class ExtraLinkController : Controller
    {       
        private readonly IComponentExtraLinkAppService _componentExtraLink;
        private readonly IComponentExtraLinkOptionAppService _componentExtraLinkOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "cp_24";

        public ExtraLinkController(       
            IComponentExtraLinkAppService componentExtraLink,
            IComponentExtraLinkOptionAppService componentExtraLinkOption,
             IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile)
        {            
            _componentExtraLink = componentExtraLink;
            _componentExtraLinkOption = componentExtraLinkOption;
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

            ViewBag.Classe = await _componentExtraLinkOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);               
                  
            return View();
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentExtraLink.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term)
        {
            string userId = User.Identity.GetUserId();  
            var result = await _componentExtraLink.SearchAsync(term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }    

        public async Task<JsonResult> GetResultTxt(string term)
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentExtraLink.GetObjetoAsync(term, userId);          
            return Json(result);          
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string link, string textLink, string stTextLink, string description, string stDescription)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);                       

            try
            {
                JsonResponse json = await _componentExtraLink.AppUpdateAsync(id, userId, profile.SiteNumber, link, textLink, stTextLink, description, stDescription);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ExtraLinkController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentExtraLink.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ExtraLinkController", "Delete", profile.SiteNumber.ToString());
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