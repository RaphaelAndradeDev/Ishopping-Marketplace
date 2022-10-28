using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]   
    public class ViewItensController : Controller
    {
        private readonly IAccountManagerAppService _accountManagerAppService;
        private readonly IConfigUserViewItemAppService _configUserViewItem;
        private readonly IConfigUserViewAppService _configUserView;  
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        public ViewItensController(
            IAccountManagerAppService accountManagerAppService,
            IConfigUserViewItemAppService configUserViewItem,
            IConfigUserViewAppService configUserView,                   
            IUserRegisterProfileAppService userRegisterProfile)
        {
            _accountManagerAppService = accountManagerAppService;
            _configUserViewItem = configUserViewItem;
            _configUserView = configUserView;     
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

            ViewBag.views = _configUserView.GetViewTextMenu(true, userId);
            return View();           
        }

        public JsonResult GetViewItens(int viewCod)
        {
            string userId = User.Identity.GetUserId();
            var result = _configUserViewItem.GetAllUserViewItem(viewCod, userId);
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
        public JsonResult Salvar(string id, bool ativo, string textMenu, string textView)
        {
            string userId = User.Identity.GetUserId();

            try
            {
                JsonResponse json = _accountManagerAppService.AccountUpdate(userId, id, ativo, textMenu, textView);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ViewItensController", "Salvar", userId);
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