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
    public class PresentationController : Controller
    {   
        private readonly IComponentPresentationAppService _componentPresentation;
        private readonly IComponentPresentationOptionAppService _componentPresentationOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        private const string viewType = "cp_38";

        public PresentationController(       
            IComponentPresentationAppService componentPresentation,
            IComponentPresentationOptionAppService componentPresentationOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {           
            _componentPresentation = componentPresentation;
            _componentPresentationOption = componentPresentationOption;
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

            ViewBag.Classe = await _componentPresentationOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);               
            
            var result = await _componentPresentation.GetByAsync(txtTexto, ps, userId);
            if (result != null)
            {
                var presentation = Mapper.Map<ComponentPresentation, ComponentPresentationViewModel>(result);
                return View(presentation);
            }
            else
            {
                return View(ReturnViewModel());
            }          
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentPresentation.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term, int ps = 1)
        {
            string userId = User.Identity.GetUserId();         
            var result = await _componentPresentation.SearchAsync(term, ps, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, int position, string title, string stTitle, string category, string stCategory, string icon, string description, string stDescription, string imageFileName)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);            

            try
            {
                JsonResponse json = await _componentPresentation.AppUpdateAsync(id, userId, profile.SiteNumber, position, title, stTitle, category, stCategory, icon, description, stDescription, imageFileName);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = title, ps = position });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PresentationController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentPresentation.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PresentationController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        } 

        private ComponentPresentationViewModel ReturnViewModel()
        {
            var presentation = new ComponentPresentationViewModel();
            presentation.UserImageGallery = new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_210x210.jpg" };
            presentation.ComponentPresentationOption = new ComponentPresentationOptionModel() { Category = "SemEstilo", Description = "SemEstilo", Title = "SemEstilo" };
            return presentation;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}