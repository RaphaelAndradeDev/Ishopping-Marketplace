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
    public class PortofolioController : Controller
    {    
        private readonly IComponentPortofolioAppService _componentPortofolio;
        private readonly IComponentPortfolioOptionAppService _componentPortfolioOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserImageGalleryAppService _userImageGallery;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "cp_29";

        public PortofolioController(    
            IComponentPortofolioAppService componentPortofolio,
            IComponentPortfolioOptionAppService componentPortfolioOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserImageGalleryAppService userImageGallery,
            IUserRegisterProfileAppService userRegisterProfile)
        {          
            _componentPortofolio = componentPortofolio;
            _componentPortfolioOption = componentPortfolioOption;
            _configUserStyleClass = configUserStyleClass;
            _userImageGallery = userImageGallery;
            _userRegisterProfile = userRegisterProfile;
        }

        public async Task<ActionResult> Alter(string txtTexto, int position = 1)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType)) return HttpNotFound();

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "component";

            ViewBag.Classe = await _componentPortfolioOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);                   
           
            var result = await _componentPortofolio.GetByAsync(txtTexto, position, userId);
            if (result != null)
            {
                var portofolio = Mapper.Map<ComponentPortofolio, ComponentPortofolioViewModel>(result);
                return View(portofolio);
            }
            else
            {
                return View(ReturnViewModel());
            }           
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentPortofolio.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term, int position = 1)
        {
            string userId = User.Identity.GetUserId();         
            var busca = await _componentPortofolio.SearchAsync(term, position, userId);
            return Json(busca, JsonRequestBehavior.AllowGet);
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, bool displayOnPage, bool displayOnlyPage, bool portfolioHead, bool portfolioChild, int position, string title, string stitle, string description, string sdescription, string category, string scategory, string subCategory, string list, string slist, string tags, string imageFileName)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);                        

            try
            {
                JsonResponse json = await _componentPortofolio.AppUpdateAsync(id, userId, profile.SiteNumber, displayOnPage, displayOnlyPage, portfolioHead, portfolioChild, position, title, stitle, description, sdescription, category, scategory, subCategory, list, slist, tags, imageFileName);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = title, position = position });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentPortofolio.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        private ComponentPortofolioViewModel ReturnViewModel()
        {
            var portofolio = new ComponentPortofolioViewModel();
            portofolio.Id = Guid.Empty;
            portofolio.UserImageGallery = new UserImageGalleryViewModel { Folder = 1101, FileName = "Default_210x210.jpg" };
            portofolio.ComponentPortofolioOption = new ComponentPortofolioOptionModel() { Category = "SemEstilo", Description = "SemEstilo", List = "SemEstilo", Title = "SemEstilo" };
            return portofolio;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}