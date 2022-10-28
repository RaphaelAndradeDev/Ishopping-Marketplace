using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
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
    public class SimpleProductController : Controller
    {        
        private readonly IComponentSimpleProductAppService _componentSimpleProduct;
        private readonly IComponentSimpleProductOptionAppService _componentSimpleProductOption;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
    

        private const string viewType = "cp_40";

        public SimpleProductController(     
            IComponentSimpleProductAppService componentSimpleProduct,
            IComponentSimpleProductOptionAppService componentSimpleProductOption,
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile)
        {      
            _componentSimpleProduct = componentSimpleProduct;
            _componentSimpleProductOption = componentSimpleProductOption;
            _configUserStyleClass = configUserStyleClass;
            _userRegisterProfile = userRegisterProfile;     
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

            ViewBag.Classe = await _componentSimpleProductOption.GetDefaultAsync(userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);                 
                     
            var result = await _componentSimpleProduct.GetByTermAsync(txtTexto, userId);
            if (result != null)
            {                
                return View(ReturnViewModel(result));
            }
            else
            {
                return View(ReturnViewModel());
            }         
        }

        public JsonResult GetSubCategory(int categoryId)
        {
            var subCategory = new CategoryList().Category.FirstOrDefault(x => x.Id == categoryId).SubCategory.ToList();
            return Json(subCategory, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetDefaoutStyle()
        {
            string userId = User.Identity.GetUserId();
            var result = await _componentSimpleProduct.GetDefaoutStyleAsync(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetTexto(string term)
        {
            string userId = User.Identity.GetUserId(); 
            var result = await _componentSimpleProduct.SearchAsync(term, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, bool displayOnPage, bool displayOnlyPage, string name, string stName, int category, string stCategory, int subCategory, string brand, string stBrand, string model, string stModel, decimal price, string stPrice, string description, string stDescription, string tags, string img1, string img2, string img3)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);
                        
            try
            {
                JsonResponse json = await _componentSimpleProduct.AppUpdateAsync(id, userId, profile.SiteNumber, displayOnPage, displayOnlyPage, name, stName, category, stCategory, subCategory, brand, stBrand, model, stModel, price, stPrice, description, stDescription, tags, img1, img2, img3);
                json.RedirectUrl = Url.Action("Alter", new { txtTexto = name });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SimpleProductController", "Salvar", profile.SiteNumber.ToString());
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
                JsonDelete json = await _componentSimpleProduct.AppDeleteAsync(id, userId);
                json.RedirectUrl = Url.Action("Alter");
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SimpleProductController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }  

        private ComponentSimpleProductViewModel ReturnViewModel()
        {
            var product = new ComponentSimpleProductViewModel();
            product.Category = 10;
            product.SubCategory = 1001;
            var listImageGallery = new List<UserImageGalleryViewModel>() {
                    new UserImageGalleryViewModel(){ Folder=1101, FileName = "Default_650x750.jpg" },
                    new UserImageGalleryViewModel(){ Folder=1101, FileName = "Default_650x750.jpg" },
                    new UserImageGalleryViewModel(){ Folder=1101, FileName = "Default_650x750.jpg" }
                    };
            product.UserImageGallery = listImageGallery;
            product.ComponentSimpleProductOption = new ComponentSimpleProductOptionModel() { Brand = "SemEstilo", Category = "SemEstilo", Description = "SemEstilo", Model = "SemEstilo", Name = "SemEstilo", Price = "SemEstilo" };
            return product;
        }

        private ComponentSimpleProductViewModel ReturnViewModel(ComponentSimpleProduct componentSimpleProduct)
        {
            var componentSimpleProductViewModel = Mapper.Map<ComponentSimpleProduct, ComponentSimpleProductViewModel>(componentSimpleProduct);
            while (componentSimpleProductViewModel.UserImageGallery.Count < 3)
            {
                componentSimpleProductViewModel.UserImageGallery.Add(
                    new UserImageGalleryViewModel() { Folder = 1101, FileName = "Default_650x750.jpg" });
            }
            return componentSimpleProductViewModel;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}