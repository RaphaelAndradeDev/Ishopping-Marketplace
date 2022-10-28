using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.ApplicationManager.Component;
using Ishopping.ApplicationManager.Content;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.User;
using Ishopping.ViewModels.ImageGallery;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class ImageGalleryController : Controller
    {
        private readonly IAdminViewDataAppService _adminViewData;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IConfigUserViewItemAppService _configUserViewItem;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        public ImageGalleryController(
            IAdminViewDataAppService adminViewData,
            IConfigUserViewAppService configUserView,
            IConfigUserViewItemAppService configUserViewItem, 
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {
            _adminViewData = adminViewData;
            _configUserView = configUserView;
            _configUserViewItem = configUserViewItem;
            _userRegisterProfile = userRegisterProfile;
            _userImageGallery = userImageGallery;
        }               

        public async Task<ActionResult> Index()
        {
            const int fileType = 1;
            string userId = User.Identity.GetUserId();
            if (await NotExistItem(fileType)) return HttpNotFound();
            ViewBag.views = _configUserView.GetAllViewsBy(true, userId);
            return View(GetSerialize(userId));                      
        }            
                
        public async Task<ActionResult> GetImgIcon()
        {
            const int fileType = 2;
            string userId = User.Identity.GetUserId();
            if (await NotExistItem(fileType)) return HttpNotFound();
            ViewBag.views = _configUserView.GetAllViewsBy(true, userId);
            return View(GetSerialize(userId)); 
        }

        public async Task<PartialViewResult> GetImagePartial(int fileType, int viewCod)
        {
            var imageGallery = await GetImageAsync(fileType, viewCod);
            return PartialView("_GetImgPartial", imageGallery);
        }

        public async Task<ActionResult> GetImgLogo()
        {
            const int fileType = 3;
            string userId = User.Identity.GetUserId();      
            if (await NotExistItem(fileType)) return HttpNotFound();
            var imageT1ViewModel = new ImageT1ViewModel(await GetImageAsync(3, 0), GetSerialize(userId));        
            return View(imageT1ViewModel);
        }        

        public async Task<ActionResult> GetImgClient()
        {
            const int fileType = 4;
            if (await NotExistItem(fileType)) return HttpNotFound();          
            return PartialView(await GetImageAsync(fileType));        
        }

        public JsonResult ClientSearchShare(string id)
        {
            var result = new ComponentClientSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)            
                return Json(obj.Name, JsonRequestBehavior.AllowGet);       
            return Json("", JsonRequestBehavior.AllowGet);            
        }

        public async Task<ActionResult> GetImgTeam()
        {
            const int fileType = 5;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType)); 
        }

        public JsonResult TeamSearchShare(string id)
        {
            var result = new ComponentTeamSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Name, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);             
        }

        public async Task<ActionResult> GetImgBrand()
        {
            const int fileType = 6;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));           
        }

        public async Task<JsonResult> BrandSearchShare(string id)
        {
            var result = new ComponentBrandSearch(Guid.Parse(id));
            var obj = await result.ImageSearch();
            if (obj != null)            
                return Json(obj.Marca, JsonRequestBehavior.AllowGet);       
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgPortofolio()
        {
            const int fileType = 7;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));   
        }

        public JsonResult PortofolioSearchShare(string id)
        {
            var result = new ComponentPortofolioSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Title, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgProjects()
        {
            const int fileType = 8;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));
        }

        public JsonResult ProjectsSearchShare(string id)
        {
            var result = new ComponentProjectSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Title, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgProd()
        {
            const int fileType = 9;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));
        }

        public JsonResult ProdSearchShare(string id)
        {
            var result = new ComponentProductSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Name, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgPost()
        {
            const int fileType = 10;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));              
        }

        public JsonResult PostSearchShare(string id)
        {
            var result = new ComponentPostSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Titulo, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgService()
        {
            const int fileType = 11;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));    
        }

        public JsonResult ServiceSearchShare(string id)
        {
            var result = new ComponentServiceSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Title, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgCard()
        {
            const int fileType = 12;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType)); 
        }

        public JsonResult CardSearchShare(string id)
        {
            var result = new ConfigUserDisplaySearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.UserImageGallery.FileName, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgCarte()
        {
            const int fileType = 13;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType)); 
        }

        public JsonResult CarteSearchShare(string id)
        {
            var result = new ComponentMenuSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Title, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgThumbnail()
        {
            const int fileType = 14;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));
        }

        public JsonResult ThumbnailSearchShare(string id)
        {
            var result = new ComponentThumbnailSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.UserImageGallery.FileName, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgPresentation()
        {
            const int fileType = 15;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType)); 
        }

        public JsonResult PresentationSearchShare(string id)
        {
            var result = new ComponentPresentationSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Title, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        public async Task<ActionResult> GetImgSlider()
        {
            const int fileType = 16;
            if (await NotExistItem(fileType)) return HttpNotFound();
            return PartialView(await GetImageAsync(fileType));
        }

        public JsonResult SliderSearchShare(string id)
        {
            var result = new ContentSliderSearch(Guid.Parse(id));
            var obj = result.ImageSearch();
            if (obj != null)
                return Json(obj.Position, JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);   
        }

        // ##########################################################
        public void Edit(string p, int t)           
        {
            string userId = User.Identity.GetUserId();                                
            var all = _userImageGallery.GetAllBy(t, userId).OrderBy(x => x.Position).ToList();

            string[] split = p.Split(new Char[] {','});

            int j = 1;
            foreach (var item in all)
            {                
                item.Change(Convert.ToInt32(split[j++]));                                   
            }         
            _userImageGallery.UpdateAll(all);
            SetSerialize(userId, true);
        }
     
        public ActionResult Delete(string id, string view)
        {
            string userId = User.Identity.GetUserId();
            var ig = _userImageGallery.GetById(id, userId);
            if(ig == null)
                return HttpNotFound();

            string[] sizes = new string[8] {"","_tb","_xs","_s","_xm","_m","_xl","_l"};
            string filePath = Server.MapPath("~/Content/uploads/" + ig.Folder + "/" + ig.FileName);

            string directory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileExt = Path.GetExtension(filePath);

            foreach (var size in sizes)
            {
                string path = Path.Combine(directory, fileName + size + fileExt);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }            

            if (ig.FileType <= 3) SetSerialize(userId, true);
            _userImageGallery.Remove(ig);

            var viewresult = Json(new { error = String.Empty });            
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain";

            return RedirectToAction(view);
        }

        public JsonResult GetAppMenu()
        {
            string userId = User.Identity.GetUserId();
            var getAppMenu = _userRegisterProfile.GetBasicProfile(userId).AppMenu;
            return Json(new { data = getAppMenu, activeFor = "image" }, JsonRequestBehavior.AllowGet);
        }


        // Private Methods
        private  async Task<IEnumerable<UserImageGalleryViewModel>> GetImageAsync(int fileType, int viewCod)
        {
            string userId = User.Identity.GetUserId();
            var listImg = await _userImageGallery.GetAllByAsync(fileType, viewCod, userId);
            var all = listImg.OrderBy(x => x.Position).ToList();

            int p = all.Count(x => x.Position == 0);    // conta o número de imagens com posição = 0
            int t = all.Count();

            if (p > 0)                                  // se existe imagens com posição a serem marcadas
            {
                List<UserImageGallery> alt = all.Where(x => x.Position == 0).ToList();      // cria uma lista com valores de posições que não existem ou seja posições = 0                                                                                  
                int m, n, a;
                a = 1;
                m = all.Max(x => x.Position);                                           // busca a maior posição
                if (p > m) n = p; else n = m;

                foreach (var j in alt)
                {
                    for (int i = a; i <= t; i++)
                    {
                        if (!all.Exists(x => x.Position == i))
                        {
                            j.Change(i); a = i; break;
                        }
                    }
                }          
                _userImageGallery.UpdateAll(all);         
            }
            return Mapper.Map<IEnumerable<UserImageGallery>, IEnumerable<UserImageGalleryViewModel>>(all);
        }        

        private async Task<IEnumerable<UserImageGalleryViewModel>> GetImageAsync(int fileType)
        {
            string userId = User.Identity.GetUserId();        
            var listImg = await _userImageGallery.GetAllByAsync(fileType, userId);
            var all = listImg.OrderBy(x => x.Id).ToList();            
            return Mapper.Map<IEnumerable<UserImageGallery>, IEnumerable<UserImageGalleryViewModel>>(all);
        }           

        private void SetSerialize(string userId, bool serialize)
        {
            var profile = _userRegisterProfile.GetByUserId(userId);
            profile.SetSerialize(serialize);
            _userRegisterProfile.Update(profile);
        }

        private Serialize GetSerialize(string userId)
        {
            var profile = _userRegisterProfile.GetByUserId(userId);          
            var serialize = new Serialize(profile.SiteNumber, profile.Controller, profile.Serialize);
            if (profile.Serialize)
            {
                profile.SetSerialize(false);
                _userRegisterProfile.Update(profile);
            }
            return serialize;
        }

        private async Task<bool> NotExistItem(int fileType)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);
            return !profile.ExistItem(ConvertToViewType(fileType));
        }

        private string ConvertToViewType(int fileType)
        {
            switch (fileType)
            {
                case 1:
                    return "img_11";
                case 2:
                    return "img_12";
                case 3:
                    return "img_13";
                case 4:
                    return "img_23";
                case 5:
                    return "img_36";
                case 6:
                    return "img_22";
                case 7:
                    return "img_29";
                case 8:
                    return "img_32";
                case 9:
                    return "img_40";
                case 10:
                    return "img_30";
                case 11:
                    return "img_33";
                case 12:
                    return "ever";
                case 13:
                    return "img_27";
                case 14:
                    return "img_37";
                case 15:
                    return "img_38";
                case 16:
                    return "img_16";
                default:
                    return string.Empty;
            }
        }
    }
}