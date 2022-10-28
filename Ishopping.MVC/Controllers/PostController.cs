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
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class PostController : Controller    
    {        
        private readonly IComponentPostAppService _componentPost;
        private readonly IComponentPostOptionAppService _componentPostOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        private const string viewType = "cp_30";

        public PostController(          
            IComponentPostAppService componentPost,
            IComponentPostOptionAppService componentPostOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {           
            _componentPost = componentPost;
            _componentPostOption = componentPostOption;
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

            ViewBag.Classe = await _componentPostOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);     
           
            var result = await _componentPost.GetByTermAsync(txtTexto, userId);
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
            var result = await _componentPost.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term)          
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentPost.SearchAsync(term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }   

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, bool displayOnPage, bool displayOnlyPage, string model, string titulo, string stTitulo, string autor, string stAutor, string categoria, string stCategoria, string subTitulo1, string stSubTitulo, string paragrafo1, string stParagrafo, string subTitulo2, string paragrafo2, string subTitulo3, string paragrafo3, string img1, string img2, string img3, string video, string tags)
        {
            string userId = User.Identity.GetUserId();
            var profile = _userRegisterProfile.GetByUserId(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);                     

            try
            {
                JsonResponse json = await _componentPost.AppUpdateAsync(id, userId, profile.SiteNumber, profile.IsBlock(), displayOnPage, displayOnlyPage, model, titulo, stTitulo, autor, stAutor, categoria, stCategoria, subTitulo1, stSubTitulo, paragrafo1, stParagrafo, subTitulo2, paragrafo2, subTitulo3, paragrafo3, img1, img2, img3, video, tags);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = titulo });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PostController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentPost.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PostController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

       private ComponentPostViewModel ReturnViewModel(ComponentPost componentPost)
        {
            var componentPostViewModel = Mapper.Map<ComponentPost, ComponentPostViewModel>(componentPost);
            while (componentPostViewModel.UserImageGallery.Count < 3)
            {
                componentPostViewModel.UserImageGallery.Add(
                    new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_800x500.png" });
            }
            return componentPostViewModel;
        }
        
        private ComponentPostViewModel ReturnViewModel()
        {
            var componentPostViewModel = new ComponentPostViewModel();
            var listImageGallery = new List<UserImageGalleryViewModel>() { 
                    new UserImageGalleryViewModel(){ Folder=1101, FileName = "Default_800x500.png" },
                    new UserImageGalleryViewModel(){ Folder=1101, FileName = "Default_800x500.png" },
                    new UserImageGalleryViewModel(){ Folder=1101, FileName = "Default_800x500.png" }
                    };
            componentPostViewModel.UserImageGallery = listImageGallery;
            componentPostViewModel.Model = "_PartialPost_1";
            componentPostViewModel.Categoria = "Utilidade Pública";
            componentPostViewModel.ComponentPostOption = new ComponentPostOptionModel() { Autor = "SemEstilo", Categoria = "SemEstilo", Paragrafo = "SemEstilo", SubTitulo = "SemEstilo", Titulo = "SemEstilo" };
            return componentPostViewModel;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}