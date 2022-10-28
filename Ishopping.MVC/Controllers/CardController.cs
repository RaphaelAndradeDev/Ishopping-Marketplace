using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.Config;
using Ishopping.MVC.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class CardController : Controller
    {   
        private readonly IConfigUserDisplayAppService _configUserDisplay;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;      

        public CardController(       
            IConfigUserDisplayAppService configUserDisplay, 
            IUserRegisterProfileAppService userRegisterProfile)
        {           
            _configUserDisplay = configUserDisplay;
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

            var result = _configUserDisplay.GetByUserId(userId);
            if(result != null)
            {
                var display = Mapper.Map<ConfigUserDisplay, ConfigUserDisplayViewModel>(result);
                return View(display); 
            }
            else
            {
                var display = new ConfigUserDisplayViewModel();
                display.UserImageGallery = new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_210x210.jpg" };
                return View(display);   
            }                   
        }

        [AjaxValidateAntiForgeryToken]
        public JsonResult Salvar(string id, string title, string message, string imageFileName)
        {
            string userId = User.Identity.GetUserId();      

            try
            {
                JsonResponse json = _configUserDisplay.AppUpdate(userId, title, message, imageFileName);
                json.RedirectUrl = Url.Action("Alter", "Card");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "CardController", "Salvar", userId);
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