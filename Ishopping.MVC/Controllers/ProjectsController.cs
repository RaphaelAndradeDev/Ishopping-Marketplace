using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.Component;
using Ishopping.MVC.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class ProjectsController : Controller
    {     
        private readonly IComponentProjectAppService _componentProject;
        private readonly IComponentProjectOptionAppService _componentProjectOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        private const string viewType = "cp_32";

        public ProjectsController(          
            IComponentProjectAppService componentProject,
            IComponentProjectOptionAppService componentProjectOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {     
            _componentProject = componentProject;
            _componentProjectOption = componentProjectOption;
            _configUserStyleClass = configUserStyleClass;
            _userRegisterProfile = userRegisterProfile;
            _userImageGallery = userImageGallery;
        }

        public async Task<ActionResult> Alter(string txtTexto)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType)) return HttpNotFound();

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "component";

            ViewBag.Classe = await _componentProjectOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);              
                      
            var result = await _componentProject.GetByTermAsync(txtTexto, userId);
            if (result != null)
            {
                return View(ReturnViewModel(result));
            }
            else
            {
                return View(ReturnViewModel());
            }           
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentProject.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term)
        {
            string userId = User.Identity.GetUserId();      
            var result = await _componentProject.SearchAsync(term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string name, string stName, string title, string stTitle, string client, string stClient, string description, string stDescription, string category, string stCategory, string team, string stTeam, string webSite, string urlVideo, string date, string img1, string img2, string img3)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);                        

            try
            {
                JsonResponse json = await _componentProject.AppUpdateAsync(id, userId, profile.SiteNumber, name, stName, title, stTitle, client, stClient, description, stDescription, category, stCategory, team, stTeam, webSite, urlVideo, date, img1, img2, img3);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = name });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ProjectController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentProject.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ProjectController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }  
   
        private ComponentProjectViewModel ReturnViewModel(ComponentProject componentProject)
        {
            var ComponentProjectViewModel = Mapper.Map<ComponentProject, ComponentProjectViewModel>(componentProject);
            while (ComponentProjectViewModel.UserImageGallery.Count < 3)
            {
                ComponentProjectViewModel.UserImageGallery.Add(
                    new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_800x500.png" });
            }
            return ComponentProjectViewModel;
        }

        private ComponentProjectViewModel ReturnViewModel()
        {
            var project = new ComponentProjectViewModel();
            var listImageGallery = new List<UserImageGalleryViewModel>() { 
                    new UserImageGalleryViewModel(){ Folder = 1101, FileName = "Default_800x500.png" },
                    new UserImageGalleryViewModel(){ Folder = 1101, FileName = "Default_800x500.png" },
                    new UserImageGalleryViewModel(){ Folder = 1101, FileName = "Default_800x500.png" }
                    };
            project.UserImageGallery = listImageGallery;
            project.DateIn = DateTime.Now;
            project.ComponentProjectOption = new ComponentProjectOptionModel() { Category = "SemEstilo", Client = "SemEstilo", Description = "SemEstilo", Name = "SemEstilo", Team = "SemEstilo", Title = "SemEstilo" };
            return project;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}