using Ishopping.Application.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using AutoMapper;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Config;
using Ishopping.Application.Common;
using Ishopping.Models;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")] 
    public class MaintenanceController : Controller
    {
        private readonly IAppViewAppService _appView;
        private readonly IConfigUserMaintenanceAppService _configUserMaintenance;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        public MaintenanceController(
            IAppViewAppService appView,
            IConfigUserMaintenanceAppService configUserMaintenance,
            IUserRegisterProfileAppService userRegisterProfile)
        {
            _appView = appView;
            _configUserMaintenance = configUserMaintenance;
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

            ViewBag.views = _appView.GetAllByType(1);
            var result = _configUserMaintenance.GetByUserId(userId);
            if(result != null)
            {
                var configUserMaintenanceViewModel = Mapper.Map<ConfigUserMaintenance, ConfigUserMaintenanceViewModel>(result);
                return View(configUserMaintenanceViewModel);
            }
            return View();
        }

        [AjaxValidateAntiForgeryToken]
        public JsonResult Salvar(string title, string message, string dateReturn, string viewName, string partialView, bool isMaintenance = false)
        {
            string userId = User.Identity.GetUserId();      

            try
            {
                JsonResponse json = _configUserMaintenance.AppUpdate(userId, title, message, dateReturn, viewName, partialView, isMaintenance);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MaintenanceController", "Salvar", userId);
                JsonError json = new JsonError(ex.ToString());
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