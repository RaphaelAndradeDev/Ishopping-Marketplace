using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.Constants;
using Ishopping.MVC.Models;
using Ishopping.MVC.ViewModels.User;
using Ishopping.ViewModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ishopping.MVC.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {                
        private readonly IAdminTemplateAppService _adminTemplate;
        private readonly IAdminViewDataAppService _adminViewData;
        private readonly IAccountManagerAppService _accountManager;
        private readonly IConfigUserMaintenanceAppService _configUserMaintenance;
        private readonly IUserFinancialHistoryAppService _userFinancialHistory;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;  

        private ApplicationDbContext _context = new ApplicationDbContext();

        public ProfilesController(                        
            IAdminTemplateAppService adminTemplate,
            IAdminViewDataAppService adminViewData,
            IAccountManagerAppService accountManager,
            IConfigUserMaintenanceAppService configUserMaintenance,
            IUserFinancialHistoryAppService userFinancialHistory,
            IUserRegisterProfileAppService userRegisterProfile)
        {                                       
            _adminTemplate = adminTemplate;
            _adminViewData = adminViewData;
            _accountManager = accountManager;
            _configUserMaintenance = configUserMaintenance;
            _userFinancialHistory = userFinancialHistory;
            _userRegisterProfile = userRegisterProfile; 
        }
           
        public ActionResult Index()
        {            
            string userId = User.Identity.GetUserId();
            var profile = _userRegisterProfile.GetByUserId(userId);
            var userRegisterProfileViewModel = Mapper.Map<UserRegisterProfile, UserAccountViewModel>(profile);                     
                          
            if (profile != null)
            {
                userRegisterProfileViewModel.IsMaintenance = _configUserMaintenance.GetIsMaintenance(userId);
                userRegisterProfileViewModel.DueDate = _userFinancialHistory.GetDueDate(userId);
                userRegisterProfileViewModel.GroupPlan = _userRegisterProfile.GetPlan(userId);               
                userRegisterProfileViewModel.GroupPlan.GroupName = ((Level.Template)userRegisterProfileViewModel.GroupPlan.KeyGroup).ToString();
                if(profile.Serialize)
                {
                    profile.SetSerialize(false);
                    _userRegisterProfile.Update(profile);
                }
            }
            return View(userRegisterProfileViewModel);
        }        

        public JsonResult GetTemplate(int group)
        {
            Price price = new Price();
            string value = price.Template(group).ToString("C");         
            var template = _adminTemplate.GetAllName(group).ToList();         
            return Json(new { template, value }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetView(int templateCod)
        {
            var views = _adminViewData.GetAllByTemplateCod(templateCod).Select(x => new { cod = x.ViewCod, name = x.ViewName}).ToList();
            return Json(views, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoteValidateSiteNumber(int SiteNumber)
        {
            string userId = User.Identity.GetUserId();
            bool result = _userRegisterProfile.ExistSiteNumber(SiteNumber, userId);
            return Json(new { valid = !result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoteValidateSiteName(string SiteName)
        {
            string userId = User.Identity.GetUserId();
            bool result = _userRegisterProfile.ExistSiteName(SiteName, userId);
            return Json(new { valid = !result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoteValidateCnpj(string Cnpj)
        {
            string userId = User.Identity.GetUserId();
            bool result = _userRegisterProfile.ExistCnpj(Cnpj, userId);
            return Json(new { valid = !result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoteValidateEmail(string Email)
        {
            string userId = User.Identity.GetUserId();
            bool result = _userRegisterProfile.ExistEmail(Email, userId);
            return Json(new { valid = !result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoteValidateEmpresa(string Empresa)
        {
            string userId = User.Identity.GetUserId();
            bool result = _userRegisterProfile.ExistEmpresa(Empresa, userId);
            return Json(new { valid = !result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoteValidateWebsite(string Website)
        {
            string userId = User.Identity.GetUserId();
            bool result = _userRegisterProfile.ExistWebsite(Website, userId);
            return Json(new { valid = !result }, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            bool existeProfile = _userRegisterProfile.ExistProfile(userId);
            if (existeProfile)
            {
                return RedirectToAction("Edit");
            }

            int[] groups = _adminTemplate.GetAll().Select(x => x.Group).Distinct().ToArray();
            var group = new Dictionary<int, string>();
            for (int i = 0; i < groups.Length; i++)
            {
                group.Add(groups[i], ((Level.Template)groups[i]).ToString());
            }
            ViewBag.Level = group; 
            return View();
        }
               
        [AjaxValidateAntiForgeryToken]
        public JsonResult CreateProfile(string dados)
        {
            try
            {             
                string userId = User.Identity.GetUserId();
                if (_userRegisterProfile.ExistProfile(userId))
                    return Json(new
                    {
                        message = "Você ja possui um profile",
                        redirectUrl = Url.Action("Index"),
                        isRedirect = true
                    });

                var profile = new JavaScriptSerializer().Deserialize<UserRegisterProfileViewModel>(dados);
                var paths = SetCssPath(profile.SiteNumber, profile.TemplateCod);

                _accountManager.AccountCreate(userId, profile.Group, profile.TemplateCod, profile.ViewStart, profile.SiteNumber, profile.SiteName, profile.Semantica1, profile.Semantica2,
                    profile.Semantica3, profile.Semantica4, profile.Empresa, profile.Cnpj, profile.Rua, profile.NumRua, profile.Distrito, profile.Cidade,
                    profile.Estado, profile.CEP, profile.Pais, profile.Telefone, profile.Telefone2, profile.WhatsApp, profile.Email, profile.Website, true, profile.Latitude, profile.Longitude, paths);

                AddRolesForProfile(userId);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "Profiles", "CreateProfile");

                return Json(new
                {
                    message = "Ocorreu um erro na tentativa de salvar o profile",
                    redirectUrl = Url.Action("Index"),
                    isRedirect = false
                });
            }
            return Json(new
            {
                message = "",
                redirectUrl = Url.Action("Index"),
                isRedirect = true
            });                      
        }           
               
        public ActionResult Edit()
        {            
            string userId = User.Identity.GetUserId();
            var profile = _userRegisterProfile.GetByUserId(userId);

            if (profile == null) return HttpNotFound();

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "dados";

            var userRegisterProfileViewModel = Mapper.Map<UserRegisterProfile, UserRegisterProfileViewModel>(profile);
            return View(userRegisterProfileViewModel);
        }
              
        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult Salvar(string data)
        {           
            string userId = User.Identity.GetUserId();
            var pf = new JavaScriptSerializer().Deserialize<UserRegisterProfileViewModel>(data);    
           
            try 
	        {
                JsonResponse json = _userRegisterProfile.AppUpdate(userId, pf.SiteName, pf.Semantica1, pf.Semantica2, pf.Semantica3, pf.Semantica4, pf.Rua, pf.NumRua, pf.Distrito, pf.Cidade, pf.Estado, pf.CEP, pf.Telefone, pf.Telefone2, pf.WhatsApp, pf.Empresa, pf.Cnpj, pf.Email, pf.Website, pf.Latitude, pf.Longitude, pf.Message);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
	        catch (Exception ex)
	        {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "Profiles", "Salvar", pf.SiteNumber.ToString());
                return Json("Erro na tentativa de salvar dados");               
	        }              
        }        

        private string[] SetCssPath(int siteNumber, int templateCod)
        {
            string userPath = "~/Content/uploads/" + siteNumber.ToString();           

            string[] cssPaths = _adminTemplate.GetCssPath(templateCod).Split(',');
            string[] paths = new string[cssPaths.Count()];

            // Adiciona novo diretorio se este não existir
            string serverPath = Server.MapPath(userPath);
            if (!System.IO.Directory.Exists(serverPath))
            {
                System.IO.Directory.CreateDirectory(serverPath);
            }

            // Adiciona os arquivos css padrão 
            for (int i = 0; i < cssPaths.Count(); i++)
            {
                paths[i] = Server.MapPath(cssPaths[i]);
                string fName = Path.GetFileName(cssPaths[i]);
                System.IO.File.Copy(paths[i], Server.MapPath(Path.Combine(userPath, fName)), true);
            }

            // Adiciona o arquivo css iscss se este não existir
            string iscssPath = Server.MapPath(Path.Combine(userPath, "iscss.css"));
            if (!System.IO.File.Exists(iscssPath))
            {                
                string createText = "";
                System.IO.File.WriteAllText(iscssPath, createText);
            }

            return paths;
        }

        private void AddRolesForProfile(string userId)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.AddToRole(userId, "ExProfile");
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}
