using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.Component;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class SocialNetworksController : Controller
    {        
        private readonly IComponentSocialNetworkAppService _componentSocialNetwork;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "cp_35";

        public SocialNetworksController(        
            IComponentSocialNetworkAppService componentSocialNetwork,
            IUserRegisterProfileAppService userRegisterProfile)
        {          
            _componentSocialNetwork = componentSocialNetwork;
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

            ViewBag.Redes = _componentSocialNetwork.GetAdminSocialNetworks(userId);               

            var result = await _componentSocialNetwork.GetAllByUserIdAsync(userId);
            var socialNetworkViewModel = Mapper.Map<IEnumerable<ComponentSocialNetwork>, IEnumerable<ComponentSocialNetworkViewModel>>(result);            
            return View(socialNetworkViewModel);
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string rede, string link)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);    

            try
            {
                JsonResponse json = await _componentSocialNetwork.AppUpdateAsync(id, userId, rede.Trim(), link);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SocialNetworkController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentSocialNetwork.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SocialNetworkController", "Delete", profile.SiteNumber.ToString());
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