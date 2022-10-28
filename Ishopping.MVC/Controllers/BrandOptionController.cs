﻿using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Models;
using Ishopping.MVC;
using Ishopping.ViewModels.Option;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")] 
    public class BrandOptionController : Controller
    {   
        private readonly IConfigUserViewItemAppService _configUserViewItem;      
        private readonly IComponentBrandOptionAppService _componentBrandOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;   
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "cp_22";

        public BrandOptionController(        
            IConfigUserViewItemAppService configUserViewItem,        
            IComponentBrandOptionAppService componentBrandOption, 
            IConfigUserStyleClassAppService configUserStyleClass,          
            IUserRegisterProfileAppService userRegisterProfile)
        {            
            _configUserViewItem = configUserViewItem;        
            _componentBrandOption = componentBrandOption;
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

            var optionViewModel = new BrandOptionViewModel();          
            optionViewModel.BasicUserViewItem = await _configUserViewItem.GetBasicViewItemAsync(22, userId);
            optionViewModel.ComponentBrandOption = await _componentBrandOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);                      

            return View(optionViewModel);      
        }        

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string textView, string styleTextView, string subTitleView, string styleSubTitleView, string marca, string comment)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                const int viewCod = 22;               
                _configUserViewItem.SetConfigUserViewItemOption(textView, styleTextView, subTitleView, styleSubTitleView, viewCod, userId);
                JsonResponse json = await _componentBrandOption.AppUpdateAsync(marca, comment, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "BrandOptionController", "Salvar", profile.SiteNumber.ToString());
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