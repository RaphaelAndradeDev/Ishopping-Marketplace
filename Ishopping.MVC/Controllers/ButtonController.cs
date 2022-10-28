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
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class ButtonController : Controller
    {      
        private readonly IContentButtonAppService _contentButton;
        private readonly IContentButtonOptionAppService _contentButtonOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "ct_11";

        public ButtonController(           
            IContentButtonAppService contentButton,
            IContentButtonOptionAppService contentButtonOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IConfigUserViewAppService configUserView,
            IUserRegisterProfileAppService userRegisterProfile)
        {            
            _contentButton = contentButton;
            _contentButtonOption = contentButtonOption;
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

            ViewBag.views = _configUserView.GetAllNumButtonBy(true, userId);
            ViewBag.Classe = await _contentButtonOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);                    

            return View();
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentButton.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(int viewCod, string term)          
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentButton.SearchAsync(term, viewCod, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }              

        public async Task<JsonResult> GetResultPs(int viewCod, int ps)          
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentButton.GetObjetoAsync(viewCod, ps, userId);    
            return Json(result, JsonRequestBehavior.AllowGet);                 
        }

        public async Task<JsonResult> GetResultTxt(int viewCod, string term)
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentButton.GetObjetoAsync(viewCod, term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);            
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar( string id, int viewCod, int position, string textBtn, string stTextBtn, string textUrl)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonResponse json = await _contentButton.AppUpdateAsync(id, userId, profile.SiteNumber, viewCod, position, textBtn, stTextBtn, textUrl);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ButtonController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _contentButton.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter", "Button");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ButtonController", "Delete", profile.SiteNumber.ToString());
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