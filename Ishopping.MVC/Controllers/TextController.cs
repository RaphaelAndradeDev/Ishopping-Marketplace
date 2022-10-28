using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute (Roles = "ExProfile")]   
    public class TextController : Controller
    {
     
        private readonly IContentTextAppService _contentText;
        private readonly IContentTextOptionAppService _contentTextOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "ct_14";

        public TextController(          
            IContentTextAppService contentText, 
            IContentTextOptionAppService contentTextOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IConfigUserViewAppService configUserView,
            IUserRegisterProfileAppService userRegisterProfile)
        {           
            _contentText = contentText;
            _contentTextOption = contentTextOption;
            _configUserStyleClass = configUserStyleClass;
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

            ViewBag.views = _configUserView.GetAllTextBy(true, userId);
            ViewBag.Classe = await _contentTextOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
                   
            return View();
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentText.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(int viewCod, string term)          
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentText.SearchAsync(term, viewCod, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetResultPs(int viewCod, int ps)          
        {
            string userId = User.Identity.GetUserId();   
            var result = await _contentText.GetObjetoAsync(viewCod, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);        
        }

        public async Task<JsonResult> GetResultTxt(int viewCod, string term)
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentText.GetObjetoAsync(viewCod, term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);           
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int viewCod, int position, string text32, string stText32, string text512, string stText512, string text5120, string stText5120)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonResponse json = await _contentText.AppUpdateAsync(id, userId, profile.SiteNumber, viewCod, position, text32, stText32, text512, stText512, text5120, stText5120);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TextController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _contentText.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter", "Text");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TextController", "Delete", profile.SiteNumber.ToString());
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
