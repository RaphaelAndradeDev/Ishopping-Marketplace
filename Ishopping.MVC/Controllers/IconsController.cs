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
    public class IconsController : Controller
    {    
        private readonly IContentIconAppService _contentIcon;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "ct_12";

        public IconsController(          
            IContentIconAppService contentIcon,
            IConfigUserViewAppService configUserView,
            IUserRegisterProfileAppService userRegisterProfile)
        {          
            _contentIcon = contentIcon;
            _configUserView = configUserView;
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

            ViewBag.views = _configUserView.GetAllVectorIconBy(true, userId);                        

            return View();
        }

        public async Task<JsonResult> GetTexto(int viewCod, string term)
        {
            string userId = User.Identity.GetUserId();       
            var result = await _contentIcon.SearchAsync(term, viewCod, userId);       
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetResultPs(int viewCod, int ps)
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentIcon.GetObjetoAsync(viewCod, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);      
        }

        public async Task<JsonResult> GetResultTxt(int viewCod, string term)
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentIcon.GetObjetoAsync(viewCod, term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);      
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int viewCod, int position, string icon)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonResponse json = await _contentIcon.AppUpdateAsync(id, userId, profile.SiteNumber, viewCod, position, icon);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "IconsController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _contentIcon.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "IconsController", "Delete", profile.SiteNumber.ToString());
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
