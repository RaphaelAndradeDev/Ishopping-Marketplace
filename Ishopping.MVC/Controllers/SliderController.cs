using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Constants;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class SliderController : Controller   
    {
        private readonly IAdminViewDataAppService _adminViewData;
        private readonly IAdminSliderAppService _adminSlider;
        private readonly IAdminSliderConfigAppService _adminSliderConfig;
        private readonly IConfigUserViewAppService _configUserView;
        private readonly IContentSliderAppService _contentSlider;
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;     
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        private const string viewType = "ct_16";

        public SliderController(
            IAdminViewDataAppService adminViewData,
            IAdminSliderAppService adminSlider,
            IAdminSliderConfigAppService adminSliderConfig,
            IConfigUserViewAppService configUserView,
            IContentSliderAppService contentSlider,
            IConfigUserStyleClassAppService configUserStyleClass,       
            IUserRegisterProfileAppService userRegisterProfile)
        {
            _adminViewData = adminViewData;
            _adminSlider = adminSlider;
            _adminSliderConfig = adminSliderConfig;
            _configUserView = configUserView;
            _contentSlider = contentSlider;
            _configUserStyleClass = configUserStyleClass;        
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
            ViewBag.ActiveFor = "content";
       
            ViewBag.views = _configUserView.GetAllTextBy(true, userId);
            ViewBag.ClassName = await _configUserStyleClass.GetAllClassNameAsync(userId);
             
            return View();
        }

        public JsonResult GetSlideType(int viewCod)
        {
            int[] group = _adminSliderConfig.GetAllSlideType(viewCod);
            int maxPs = _adminViewData.GetByViewCod(viewCod).NumSlider;
            List<AppDictionary> slideType = new List<AppDictionary>();

            for (int i = 0; i < group.Length; i++)
            {
                slideType.Add(new AppDictionary { Key = group[i], Value = ConstantSlider.SliderType(group[i]) }); // retorna ex: key=2, value=Slider para texto
            }
            return Json(new { maxps = maxPs, admSt = slideType }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSlideName(int viewCod, int slideType)
        {
            string[] slideName = _adminSliderConfig.GetAllSlideName(viewCod, slideType);
            return Json(slideName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSlideClass(int viewCod, int slideType, string slideName)
        {
            string[] slideClass = _adminSliderConfig.GetAllSlideClass(viewCod, slideType, slideName);
            return Json(slideClass, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetResult( int viewCod, int ps, int item)
        {
            string userId = User.Identity.GetUserId();

            int maxPs = _adminViewData.GetByViewCod(viewCod).NumSlider;
            if(ps > maxPs)
                return Json(new { maxps = maxPs }, JsonRequestBehavior.AllowGet);

            var contentSliders = await _contentSlider.GetAllByViewCodAsync(viewCod, ps, userId);

            string slideType = null;
            if(contentSliders.Count >= item)
            {
                slideType = ConstantSlider.SliderType(contentSliders[item - 1].SliderType); // retorna ex: Slider para texto
            }            

            int[] group = _adminSliderConfig.GetAllSlideType(viewCod);
            List<AppDictionary> dictionary = new List<AppDictionary>();

            for (int i = 0; i < group.Length; i++)
            {
                dictionary.Add(new AppDictionary { Key = group[i], Value = ConstantSlider.SliderType(group[i]) }); // retorna ex: key=2, value=Slider para texto
            }

            if (contentSliders.Count >= item)
            {
                var contentSlider = contentSliders[item -1];
                return Json(new { maxps = maxPs, cs = contentSlider, st = slideType, admSt = dictionary }, JsonRequestBehavior.AllowGet);
            }
            else
            {          
                return Json(new ContentSlider(), JsonRequestBehavior.AllowGet);
            }
        }              

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string data)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            if (!profile.ExistItem(viewType))
                return Json(new JsonPageNotFound(), JsonRequestBehavior.AllowGet);

            var contentSlider = new JavaScriptSerializer().Deserialize<ContentSlider>(data);

            try
            {
                JsonResponse json = await _contentSlider.AppUpdateAsync(userId, contentSlider);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SliderController", "Salvar", profile.SiteNumber.ToString());
                JsonError json = new JsonError(contentSlider.Id.ToString(), ex.ToString());
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
                JsonDelete json = await _contentSlider.AppDeleteAsync(id, userId);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SliderController", "Delete", profile.SiteNumber.ToString());
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