using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.MVC.Models;
using Ishopping.MVC.ViewModels.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigUserDisplayAppService _configUserDisplay;

        public HomeController(IConfigUserDisplayAppService configUserDisplay)
        {
            _configUserDisplay = configUserDisplay;
        }

        private ApplicationDbContext db = new ApplicationDbContext();       

        public async Task<ActionResult> Index(int? id)
        {
            if (id.HasValue)
            {
                var userDisplay = await _configUserDisplay.GetBySiteNumberAsync(id.Value);
                if (userDisplay != null)
                    return RedirectToAction("Index", userDisplay.Controller, new { id = id });
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.SupportEmail = ConfigurationManager.AppSettings["supportEmail"]; ;
            return View();
        }

        public ActionResult TermsOfUse()
        {
            return View();
        }

        public ActionResult Tutorial()
        {
            return View();
        }

        public async Task<PartialViewResult> GetResult(double lat = 0, double lon = 0)
        {            
            var configUserDisplay = new List<ConfigUserDisplayViewModel>();            
            try 
            {
                var result = await _configUserDisplay.GetAllByGeolocationAsync(lat, lon);  
                configUserDisplay = Mapper.Map<IEnumerable<ConfigUserDisplay>, IEnumerable<ConfigUserDisplayViewModel>>(result).ToList();                
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "GetResult");           
            }
            return PartialView("_PartialGetResult", configUserDisplay);
        }

        public async Task<PartialViewResult> GetBySearch(string semantic, string address)
        {
            var configUserDisplay = new List<ConfigUserDisplayViewModel>();
            try
            {
                var result = await _configUserDisplay.GetBySearchAsync(semantic, address);
                configUserDisplay = Mapper.Map<IEnumerable<ConfigUserDisplay>, IEnumerable<ConfigUserDisplayViewModel>>(result).ToList();
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "GetBySearch");
            }
            return PartialView("_PartialGetResult", configUserDisplay);
        }

        public async Task<PartialViewResult> GetSpecific(string semantic, string address)
        {            
            var configUserDisplay = new List<ConfigUserDisplayViewModel>();
            try
            {
                var result = await _configUserDisplay.GetSpecificAsync(GetSpecificValue(semantic, address));
                configUserDisplay = Mapper.Map<IEnumerable<ConfigUserDisplay>, IEnumerable<ConfigUserDisplayViewModel>>(result).ToList();
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "GetSpecific");
            }
            return PartialView("_PartialGetResult", configUserDisplay);
        }

        public async Task<JsonResult> SearchSpecific(string term)
        {
            try
            {
                List<string> result = (await _configUserDisplay.SearchSpecificAsync(term)).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "SearchSpecific");
            }        
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SearchSpecificAd(string term)
        {
            try
            {
                List<string> result = (await _configUserDisplay.SearchSpecificAdressAsync(term)).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "SearchSpecificAd");
            }           
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SearchBySemantic(string term)        
        {
            try
            {
                List<string> result = (await _configUserDisplay.SearchBySemanticAsync(term)).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "SearchBySemantic");
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SearchByAddress(string term)       
        {
            try
            {
                List<string> result = (await _configUserDisplay.SearchByAddressAsync(term)).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HomeController", "SearchByAddress");
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }                
               

        [Authorize]
        public ActionResult TemplateView()
        {
            return View();
        }

        // Usado para SEO
        public ActionResult SeoPost_1()
        {
            return View();
        }

        public ActionResult SeoPost_2()
        {
            return View();
        }

        public ActionResult SeoPost_3()
        {
            return View();
        }


        // Private Methods
        private string GetSpecificValue(string value1, string value2)
        {
            return string.IsNullOrEmpty(value1) ? value2 : value1;       
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}