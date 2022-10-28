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
    public class TeamController : Controller
    {        
        private readonly IComponentTeamAppService _componentTeam;
        private readonly IComponentTeamOptionAppService _componentTeamOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;     
        private readonly IComponentTeamSocialNetworkAppService _componentTeamSocialNetwork;

        private const string viewType = "cp_36";

        public TeamController(         
            IComponentTeamAppService componentTeam,
            IComponentTeamOptionAppService componentTeamOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery,        
            IComponentTeamSocialNetworkAppService componentTeamSocialNetwork)
        {          
            _componentTeam = componentTeam;
            _componentTeamOption = componentTeamOption;
            _configUserStyleClass = configUserStyleClass;
            _userRegisterProfile = userRegisterProfile;
            _userImageGallery = userImageGallery;           
            _componentTeamSocialNetwork = componentTeamSocialNetwork;
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

            ViewBag.Classe = await _componentTeamOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
            ViewBag.Redes = _componentTeamSocialNetwork.GetAdminSocialNetworks(userId);               
                      
            var result = await _componentTeam.GetByTermAsync(txtTexto, userId);
            if (result != null)
            {
                var team = Mapper.Map<ComponentTeam, ComponentTeamViewModel>(result);
                return View(team);
            }
            else
            {
                return View(ReturnViewModel());
            }                
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentTeam.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term)
        {
            string userId = User.Identity.GetUserId();         
            var result = await _componentTeam.SearchAsync(term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }       

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string name, string stName, string functio, string stFunctio, string description, string stDescription, string imageFileName)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);
                        
            try
            {
                JsonResponse json = await _componentTeam.AppUpdateAsync(id, userId, profile.SiteNumber, name, stName, functio, stFunctio, description, stDescription, imageFileName);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = name });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TeamController", "Salvar", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            } 
        }

        public async Task<JsonResult> SalvarSn(string id, string idSn, string link, string rede)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);                       

            try
            {
                JsonResponse json = await _componentTeamSocialNetwork.AppUpdateAsync(id, idSn, userId, link, rede);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = json.Term });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TeamController", "SalvarSn", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentTeam.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TeamController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> DeleteSn(string idSn)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            try
            {
                JsonDelete json = await _componentTeam.AppDeleteSnAsync(idSn, userId);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = json.Term });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TeamController", "DeleteSn", profile.SiteNumber.ToString());
                JsonError json = new JsonError(idSn, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        } 
     
        private ComponentTeamViewModel ReturnViewModel()
        {
            var team = new ComponentTeamViewModel();            
            team.UserImageGallery = new UserImageGalleryViewModel { Folder = 1101, FileName = "Default_210x210.jpg" };
            team.ComponentTeamSocialNetwork = new List<ComponentTeamSocialNetworkViewModel>();
            team.ComponentTeamOption = new ComponentTeamOptionModel() { Description = "SemEstilo", Functio = "SemEstilo", Name = "SemEstilo" };
            return team;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
     
}