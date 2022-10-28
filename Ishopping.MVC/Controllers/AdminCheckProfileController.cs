using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.MVC;
using Ishopping.MVC.ViewModels.User;
using Ishopping.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ishopping.Controllers
{
    [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
    public class AdminCheckProfileController : Controller
    {
        private readonly IUserImageGalleryAppService _userImageGallery;
        private readonly IUserRegisterProfileAppService _userRegisterProfileAppService;

        public AdminCheckProfileController(
            IUserImageGalleryAppService userImageGallery,
            IUserRegisterProfileAppService userRegisterProfileAppService)
        {
            _userImageGallery = userImageGallery;
            _userRegisterProfileAppService = userRegisterProfileAppService;
        }

        public async Task<ActionResult> ImageProfile(int? fileType)
        {

            if(fileType.HasValue)
            {
                var result = await _userImageGallery.GetAllToVerifyAsync(fileType.Value);
                var imageGallery = Mapper.Map<IEnumerable<UserImageGallery>, IEnumerable<UserImageGalleryViewModel>>(result);
                return View(imageGallery);
            }
            else
            {
                var result = await _userImageGallery.GetAllToVerifyAsync();
                var imageGallery = Mapper.Map<IEnumerable<UserImageGallery>, IEnumerable<UserImageGalleryViewModel>>(result);
                return View(imageGallery);
            }
            
        }

        public async Task<ActionResult> ProfilesBlock()
        {
            var result = await _userRegisterProfileAppService.GetRestrictionAsync();         
            var profileContact = Mapper.Map<IEnumerable<ProfileContact>, IEnumerable<UserProfileContactViewModel>>(result);
            return View(profileContact);                  
        }

        public async Task<ActionResult> ProfilesBlockDetails(int id)
        {
            var result = await _userRegisterProfileAppService.GetBySiteNumberAsync(id);
            var profile = Mapper.Map<UserRegisterProfile, UserRegisterProfileViewModel>(result);
            return View(profile);
        }
                
        public ActionResult UnLockProfile(int id)
        {
            _userRegisterProfileAppService.SetRestriction(id, false);
            return RedirectToAction("ProfilesBlock");
        }

        [AjaxValidateAntiForgeryToken]
        public JsonResult Salvar(string imageChecked)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<AdminImageChecked> listAdminImageChecked = serializer.Deserialize<List<AdminImageChecked>>(imageChecked);
                _userImageGallery.SetImageCheck(listAdminImageChecked);
                return Json("");
            }
            catch (Exception)
            {
                return Json("Erro na tentativa de salvar dados");                
            }            
        }
    }
}