using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.ViewModels.Config;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class AppearanceController : Controller
    {      
        private readonly IAdminTemplateAppService _adminTemplate;
        private readonly IConfigUserAppearanceAppService _configUserAppearance;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;

        public AppearanceController(
            IAdminTemplateAppService adminTemplate,
            IConfigUserAppearanceAppService configUserAppearance,
            IUserRegisterProfileAppService userRegisterProfile)
        {            
            _adminTemplate = adminTemplate;
            _configUserAppearance = configUserAppearance;
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

            var configUserAppearance = await _configUserAppearance.GetByUserIdAsync(userId);
            if (configUserAppearance != null)
            {
                var configUserAppearanceViewModel = Mapper.Map<ConfigUserAppearance, ConfigUserAppearanceViewModel>(configUserAppearance);
                return View(configUserAppearanceViewModel);
            }
            else
            {
                return View(new ConfigUserAppearanceViewModel());
            }      
        }

        public async Task<JsonResult> GetAparencia()  // usado para restaurar padrão
        {
            string userId = User.Identity.GetUserId();

            try
            {                
                var configUserAppearance = await _configUserAppearance.GetByUserIdAsync(userId);

                foreach (var item in configUserAppearance.ConfigUserStyleColor)
                {
                    item.UserColor = item.DefaultColor;
                }

                WriteCss(userId);
                _configUserAppearance.Update(configUserAppearance);
                return Json("reload", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppearanceController", "GetAparencia", userId);
                return Json("Erro na tentativa de salvar dados", JsonRequestBehavior.AllowGet);
            }                 
        }

        [AjaxValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(string id, string data)
        {
            string userId = User.Identity.GetUserId();

            try
            {                
                var configUserAppearance = await _configUserAppearance.GetByUserIdAsync(userId);
                string[] userColor = JsonConvert.DeserializeObject<string[]>(data);
                var colors = new Dictionary<string, string>();

                int i = 0;
                foreach (var item in configUserAppearance.ConfigUserStyleColor)
                {
                    if (item.DefaultColor != userColor[i])
                    {
                        item.UserColor = userColor[i];
                        colors.Add(item.DefaultColor, item.UserColor);
                    }
                    i++;
                }

                WriteCss(userId, colors);

                JsonResponse json = _configUserAppearance.AppUpdate(configUserAppearance);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppearanceController", "Salvar", userId);
                JsonError json = new JsonError(id, ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }                    
        }

        private void WriteCss(string userId, Dictionary<string, string> colors)
        {
            var userRegisterProfile = _userRegisterProfile.GetBasicProfile(userId);

            string userPath = "~/Content/uploads/" + userRegisterProfile.SiteNumber.ToString() + "/";
            string[] cssPaths = _adminTemplate.GetByTemplateCod(userRegisterProfile.TemplateCod).CssPath.Split(',');
            string[] paths = new string[cssPaths.Count()];
            for (int j = 0; j < cssPaths.Count(); j++)
            {
                paths[j] = Server.MapPath(cssPaths[j]);
                StreamReader reader = new StreamReader(paths[j]);
                string defaultCss = reader.ReadToEnd();
                string newCss = MultipleReplace(defaultCss, colors);

                string fName = Path.GetFileName(paths[j]);
                System.IO.File.WriteAllText(Server.MapPath(Path.Combine(userPath, fName)), newCss);
            }
        }

        private void WriteCss(string userId)
        {
            var userRegisterProfile = _userRegisterProfile.GetBasicProfile(userId);

            string userPath = "~/Content/uploads/" + userRegisterProfile.SiteNumber.ToString() + "/";
            string[] cssPaths = _adminTemplate.GetByTemplateCod(userRegisterProfile.TemplateCod).CssPath.Split(',');
            string[] paths = new string[cssPaths.Count()];
            for (int j = 0; j < cssPaths.Count(); j++)
            {
                paths[j] = Server.MapPath(cssPaths[j]);
                StreamReader reader = new StreamReader(paths[j]);
                string defaultCss = reader.ReadToEnd();               

                string fName = Path.GetFileName(paths[j]);
                System.IO.File.WriteAllText(Server.MapPath(Path.Combine(userPath, fName)), defaultCss);
            }
        }

        private static string MultipleReplace(string text, Dictionary<string, string> replacements)
        {
            string retVal = text;
            foreach (string textToReplace in replacements.Keys)
            {
                retVal = retVal.Replace(textToReplace, replacements[textToReplace]);
            }
            return retVal;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}