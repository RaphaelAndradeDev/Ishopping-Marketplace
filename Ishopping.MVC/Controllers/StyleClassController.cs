using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ishopping.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class StyleClassController : Controller
    {         
   
        private readonly IConfigUserStyleClassAppService _configUserStyleClass;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        public StyleClassController(                   
            IConfigUserStyleClassAppService configUserStyleClass,
            IUserRegisterProfileAppService userRegisterProfile)
        {                      
            _configUserStyleClass = configUserStyleClass;
            _userRegisterProfile = userRegisterProfile;
        }       

        public async Task<ActionResult> Alter()
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "config";

            ViewBag.GoogleFonts = profile.GoogleFonts;

            ViewBag.StyleClass = await _configUserStyleClass.GetAllClassNameAsync(userId);               

            return View();
        }                  

        public async Task<JsonResult> GetResult(string term)
        {
            string userId = User.Identity.GetUserId();

            if(!string.IsNullOrEmpty(term))
            {
                var result = await _configUserStyleClass.GetByClassNameAsync(term, userId);
                if (result != null)
                {
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var styleClass = new ConfigUserStyleClass();
                    return Json(styleClass, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var styleClass = new ConfigUserStyleClass();       
                return Json(styleClass, JsonRequestBehavior.AllowGet);
            }            
        }               
        
        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string oldGoogleFonts, string googleFonts, string oldName, string data)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);
            var configUserStyleClass = new JavaScriptSerializer().Deserialize<ConfigUserStyleClass>(data);

            try
            {
                JsonResponse json = _configUserStyleClass.AppUpdate(userId, profile.SiteNumber, oldGoogleFonts, googleFonts, oldName, configUserStyleClass);
                WriteIsCss(profile.SiteNumber, json.Response);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StyleClassController", "Salvar", profile.SiteNumber.ToString());
                JsonError json = new JsonError(configUserStyleClass.Id.ToString(), ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }         
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(string id)
        {
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);

            try
            {
                JsonDelete json = await _configUserStyleClass.AppDeleteAsync(id, userId);
                WriteIsCss(profile.SiteNumber, json.Response);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StyleClassController", "Delete", profile.SiteNumber.ToString());
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }


        // Privete Methods
        private void WriteIsCss(int siteNumber, string iscss)
        {            
            string userPath = "~/Content/uploads/" + siteNumber.ToString();
            System.IO.File.WriteAllText(Server.MapPath(Path.Combine(userPath, "iscss.css")), iscss);   
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}