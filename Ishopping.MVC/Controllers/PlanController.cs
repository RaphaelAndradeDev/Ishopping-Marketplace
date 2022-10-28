using AutoMapper;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.Constants;
using Ishopping.MVC.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [CustomAuthorizeAttribute(Roles = "ExProfile")]
    public class PlanController : Controller
    {
        private readonly IUserFinancialAppService _userFinancial;     
        private readonly IAdminTemplateAppService _adminTemplate;
        private readonly IAdminViewDataAppService _adminViewData;
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IAccountManagerAppService _accountManager;

        public PlanController(
            IUserFinancialAppService userFinancial,     
            IAdminTemplateAppService adminTemplate,
            IAdminViewDataAppService adminViewData,
            IUserRegisterProfileAppService userRegisterProfile,
            IAccountManagerAppService accountManager)
        {
            _userFinancial = userFinancial;     
            _adminTemplate = adminTemplate;
            _adminViewData = adminViewData;
            _userRegisterProfile = userRegisterProfile;
            _accountManager = accountManager;
        }
              
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var profile = _userRegisterProfile.GetByUserId(userId);

            if (profile == null) return HttpNotFound();

            ViewBag.SiteNumber = profile.SiteNumber;
            ViewBag.Controller = profile.Controller;
            ViewBag.AppMenu = profile.AppMenu;
            ViewBag.ActiveFor = "dados";
         
            int[] groups = _adminTemplate.GetAll().Select(x => x.Group).Distinct().ToArray();
            var group = new Dictionary<int, string>();
            for (int i = 0; i < groups.Length; i++)
            {
                group.Add(groups[i], ((Level.Template)groups[i]).ToString());
            }            
            ViewBag.Level = group;

            var userFinancial = _userFinancial.GetByUserId(userId);            
            var userFinancialViewModel = Mapper.Map<UserFinancial, UserFinancialViewModel>(userFinancial);
            userFinancialViewModel.CurrentPlan = GetCurrentPlan(userFinancial);

            return View(userFinancialViewModel);
        }

        public JsonResult GetPlan()
        {           
            string userId = User.Identity.GetUserId();      
            var groupPlan = _userRegisterProfile.GetPlan(userId);       
            groupPlan.GroupName = ((Level.Template)groupPlan.KeyGroup).ToString();
            return Json(groupPlan, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlanSimulator(int group, int plan = 0)
        {
            string userId = User.Identity.GetUserId();
            var financial = _userFinancial.Simulator(userId, group, plan);
            return Json(financial, JsonRequestBehavior.AllowGet);
        }
              
        public JsonResult GetTemplate(int group, int plan = 0)
        {
            string userId = User.Identity.GetUserId();
            var financial = _userFinancial.Simulator(userId, group, plan);
            var template = _adminTemplate.GetAllByGroup(group).Select(x => new { cod = x.TemplateCod, name = x.Name }).ToList();
            return Json(new { template, financial }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetView(int templateCod)
        {
            var views = _adminViewData.GetAllByTemplateCod(templateCod).Select(x => new { cod = x.ViewCod, name = x.ViewName }).ToList();
            return Json(views, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Salvar(int group, int templateCod, int viewCod, int plan = 0)
        {
            string userId = User.Identity.GetUserId();
            var userRegisterProfile = _userRegisterProfile.GetByUserId(userId);

            try
            {
                JsonResponse json = new JsonResponse();
                // se houve troca de template
                if (templateCod != userRegisterProfile.TemplateCod)
                {
                    var cssPaths = SetCssPath(userRegisterProfile.SiteNumber, templateCod);
                    json = _accountManager.AccountUpdate(userId, group, templateCod, plan, viewCod, cssPaths);
                    json.RedirectUrl = Url.Action("Index", "Profiles");                  
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    json.Redirect = false;
                    json.Message = "Dados salvos com sucesso!";
                    return Json(json, JsonRequestBehavior.AllowGet);
                }                
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PlanController", "Salvar", userRegisterProfile.SiteNumber.ToString());
                JsonError json = new JsonError(ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }   
        }

        public JsonResult Pay(int company, string name, string email, string areaCod, string phone, string cpf)
        {
            string userId = User.Identity.GetUserId();                

            try
            {
                JsonResponse json = _userFinancial.NewPayment(userId, company, name, email, areaCod, phone, cpf);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PlanController", "Pay", userId);
                JsonError json = new JsonError(ex.ToString());
                return Json(json, JsonRequestBehavior.AllowGet);
            }              
        }


        // Private Methods
        private string[] SetCssPath(int siteNumber, int templateCod)
        {
            string userPath = "~/Content/uploads/" + siteNumber.ToString() + "/";
            string[] cssList = Directory.GetFiles(Server.MapPath(userPath), "*.css");
            foreach (string f in cssList)
            {
                string fName = Path.GetFileName(f);
                if (fName != "iscss.css")
                    System.IO.File.Delete(f);
            }

            string[] cssPaths = _adminTemplate.GetByTemplateCod(templateCod).CssPath.Split(',');
            string[] paths = new string[cssPaths.Count()];
            for (int i = 0; i < cssPaths.Count(); i++)
            {
                paths[i] = Server.MapPath(cssPaths[i]);
                string fName = Path.GetFileName(cssPaths[i]);
                System.IO.File.Copy(paths[i], Server.MapPath(Path.Combine(userPath, fName)));
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

        private int GetCurrentPlan(UserFinancial userFinancial)
        {
            return userFinancial.UserFinancialHistory.OrderBy(x => x.LastChange).Last().Group;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}