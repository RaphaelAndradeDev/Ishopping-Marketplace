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
    public class VideoController : Controller
    {
        private readonly IContentVideoAppService _contentVideo;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "ct_15";

        public VideoController(          
            IContentVideoAppService contentVideo,
            IConfigUserViewAppService configUserView,
            IUserRegisterProfileAppService userRegisterProfile)
        {          
            _contentVideo = contentVideo;
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
                   
            ViewBag.views = _configUserView.GetAllNumVideoBy(true, userId);
               
            return View();
        }

        public async Task<JsonResult> GetResultPs(int viewCod, int ps)
        {
            string userId = User.Identity.GetUserId();  
            var result = await _contentVideo.GetObjetoAsync(viewCod, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);  
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int viewCod, int position, string url)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonResponse json = await _contentVideo.AppUpdateAsync(id, userId, profile.SiteNumber, viewCod, position, url);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "VideoController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _contentVideo.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "VideoController", "Delete", profile.SiteNumber.ToString());
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