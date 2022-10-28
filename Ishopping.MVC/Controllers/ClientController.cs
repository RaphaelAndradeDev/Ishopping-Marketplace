using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.Component;
using Ishopping.MVC.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class ClientController : Controller
    {      
        private readonly IComponentClientAppService _componentClient;
        private readonly IComponentClientOptionAppService _componentClientOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        private const string viewType = "cp_23";

        public ClientController(          
            IComponentClientAppService componentClient, 
            IComponentClientOptionAppService componentClientOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {            
            _componentClient = componentClient;
            _componentClientOption = componentClientOption;
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

            ViewBag.Classe = await _componentClientOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);                   
                       
            var result = await _componentClient.GetByTermAsync(txtTexto, userId);
            if (result != null)
            {
                var client = Mapper.Map<ComponentClient, ComponentClientViewModel>(result);
                return View(client);
            }
            else
            {                   
                return View(ReturnViewModel());
            }      
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentClient.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term)
        {
            string userId = User.Identity.GetUserId();                   
            var busca = await _componentClient.SearchAsync(term, userId);
            return Json(busca, JsonRequestBehavior.AllowGet);
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string name, string stName, string functio, string stFunctio, string comment, string stComment, string project, string stProject, string site, string imageFileName)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);            

            try
            {
                JsonResponse json = await _componentClient.AppUpdateAsync(id, userId, profile.SiteNumber, name, stName, functio, stFunctio, comment, stComment, project, stProject, site, imageFileName);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = name });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ClientController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentClient.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ClientController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }    
   
        private ComponentClientViewModel ReturnViewModel()
        {
            var client = new ComponentClientViewModel();
            client.UserImageGallery = new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_210x210.jpg" };
            client.ComponentClientOption = new ComponentClientOptionModel() { Comment = "SemEstilo", Functio = "SemEstilo", Name = "SemEstilo", Projects = "SemEstilo" };
            return client;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}