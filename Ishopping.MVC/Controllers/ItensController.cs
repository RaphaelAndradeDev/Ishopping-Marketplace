using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class ItensController : Controller
    {
        private readonly IAccountManagerAppService _accountManagerAppService;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IAdminViewDataAppService _adminViewData;     
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
                
        public ItensController(
            IAccountManagerAppService accountManagerAppService,
            IConfigUserViewAppService configUserView,
            IAdminViewDataAppService adminViewData,   
            IUserRegisterProfileAppService userRegisterProfile)
        {
            _accountManagerAppService = accountManagerAppService;
            _configUserView = configUserView;
            _adminViewData = adminViewData;    
            _userRegisterProfile = userRegisterProfile;
        } 
       
        public ActionResult Alter()
        {
            string userId = User.Identity.GetUserId();
            var profile = _userRegisterProfile.GetBasicProfile(userId);

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "config";

            int templateCod = profile.TemplateCod;
            var viewsUsuario = _configUserView.GetAllViewsUser(userId);            
            ViewBag.Templates = _adminViewData.GetListViewByTemplateCod(templateCod);
            return View(viewsUsuario);
        }

        public JsonResult GetObjeto()
        {
            string userId = User.Identity.GetUserId();
            var result = _configUserView.GetAllByUserId(userId);
            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Configurações não definidas", JsonRequestBehavior.AllowGet);
            }
        }

        [AjaxValidateAntiForgeryToken]
        public JsonResult Salvar(string id, int viewCod, bool ativo, string textMenu)
        {
            string userId = User.Identity.GetUserId();

            try
            {
                JsonResponse json = _accountManagerAppService.AccountUpdate(userId, id, viewCod, ativo, textMenu);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ItensController", "Salvar", userId);
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