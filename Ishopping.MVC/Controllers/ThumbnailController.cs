using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC;
using Ishopping.MVC.ViewModels.Component;
using Ishopping.MVC.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class ThumbnailController : Controller
    {      
        private readonly IComponentThumbnailAppService _componentThumbnail;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        private const string viewType = "cp_37";

        public ThumbnailController(       
            IComponentThumbnailAppService componentThumbnail, 
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {           
            _componentThumbnail = componentThumbnail;
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
                       
            var result = await _componentThumbnail.GetByTermAsync(txtTexto, userId);
            if (result != null)
            {
                var thumbnail = Mapper.Map<ComponentThumbnail, ComponentThumbnailViewModel>(result);
                return View(thumbnail);
            }
            else
            {
                return View(ReturnViewModel());
            }        
        }        

        public async Task<JsonResult> GetTexto(string term)
        {
            string userId = User.Identity.GetUserId();    
            var result = await _componentThumbnail.SearchAsync(term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string category, string icon, string webSite, string imageFileName)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);
                        
            try
            {
                JsonResponse json = await _componentThumbnail.AppUpdateAsync(id, userId, profile.SiteNumber, category, icon, webSite, imageFileName);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = imageFileName });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ThumbnailController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentThumbnail.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ThumbnailController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        private ComponentThumbnailViewModel ReturnViewModel()
        {
            ComponentThumbnailViewModel thumbnail = new ComponentThumbnailViewModel();
            thumbnail.UserImageGallery = new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_210x210.jpg" };
            return thumbnail;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}