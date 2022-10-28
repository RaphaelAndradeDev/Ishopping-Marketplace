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
    public class ListController : Controller
    {   
        private readonly IContentListAppService _contentList;
        private readonly IContentListOptionAppService _contentListOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "ct_13";

        public ListController(          
            IContentListAppService contentList,
            IContentListOptionAppService contentListOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IConfigUserViewAppService configUserView,
            IUserRegisterProfileAppService userRegisterProfile)
        {            
            _contentList = contentList;
            _contentListOption = contentListOption;
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

            ViewBag.views = _configUserView.GeAllListBy(true, userId);
            ViewBag.Classe = await _contentListOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);                   

            return View();
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();        
            var result = await _contentList.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetResultPs(int viewCod, int ps)
        {
            string userId = User.Identity.GetUserId();
            var result = await _contentList.GetObjetoAsync(viewCod, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }    

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int viewCod, int position, string lista, string stLista)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonResponse json = await _contentList.AppUpdateAsync(id, userId, profile.SiteNumber, viewCod, position, lista, stLista);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ListController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _contentList.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter", "List");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ListController", "Delete", profile.SiteNumber.ToString());
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