using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.Component;
using Ishopping.MVC.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")] 
    public class ServicesController : Controller
    {   
        private readonly IComponentServiceAppService _componentService;
        private readonly IComponentServiceOptionAppService _componentServiceOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        private const string viewType = "cp_33";

        public ServicesController(         
            IComponentServiceAppService componentService,
            IComponentServiceOptionAppService componentServiceOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {          
            _componentService = componentService;
            _componentServiceOption = componentServiceOption;
            _configUserStyleClass = configUserStyleClass;
            _userRegisterProfile = userRegisterProfile;
            _userImageGallery = userImageGallery; 
        }

        public async Task<ActionResult> Alter(string txtTexto, int ps = 1)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType)) return HttpNotFound();

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "component";

            ViewBag.Classe = await _componentServiceOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);               
                      
            var result = await _componentService.GetByAsync(txtTexto, ps, userId);
            if (result != null)
            {
                var service = Mapper.Map<ComponentService, ComponentServiceViewModel>(result);
                return View(service);
            }
            else
            {
                return View(ReturnViewModel());
            }         
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentService.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term, int ps = 1)
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentService.SearchAsync(term, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int position, string title, string stTitle, string description, string stDescription, string imageFileName)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);
                        
            try
            {
                JsonResponse json = await _componentService.AppUpdateAsync(id, userId, profile.SiteNumber, position, title, stTitle, description, stDescription, imageFileName);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = title, ps = position });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ServiceController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentService.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ServiceController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }   
   
        private ComponentServiceViewModel ReturnViewModel()
        {
            var service = new ComponentServiceViewModel();
            service.UserImageGallery = new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_210x210.jpg" };
            service.ComponentServiceOption = new ComponentServiceOptionModel() { Description = "SemEstilo", Title = "SemEstilo" };
            return service;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}