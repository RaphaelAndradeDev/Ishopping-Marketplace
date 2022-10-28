using Ishopping.Application;
using Ishopping.Application.Interface;
using Ishopping.ViewModels.TemplateBasicPro;
using System;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Ishopping.Models;
using System.Threading.Tasks;

namespace Ishopping.MVC.Controllers.BasicPro
{
    public class DoctorController : Controller
    {
        private readonly IndexDoctorViewModelSerialize _indexDoctorViewModels;
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;
        const int viewCod = 3100;
        
        public DoctorController(
            IndexDoctorViewModelSerialize indexDoctorViewModels,
            UserSerializeViewDataAppService userSerializeViewDataAppService)
        {
            _indexDoctorViewModels = indexDoctorViewModels;
            _userSerializeViewDataAppService = userSerializeViewDataAppService;
        }

        public async Task<ActionResult> Index(int id = 0)
        {
            // Redirecionamento
            if (id == 0)
                return RedirectToAction("PageNotFound", "AppView");  

            try
            {
                var result = await _userSerializeViewDataAppService.GetBySiteNumberAsync(id, viewCod);

                if (result == null)
                    return RedirectToAction("PageNotFound", "AppView");  

                if (result.IsBlock)
                {
                    string userId = User.Identity.GetUserId();
                    if (userId != result.IdUser)
                        return RedirectToAction("PageNotFound", "AppView"); 
                }

                if (result.IsMaintenance)
                {
                    string userId = User.Identity.GetUserId();
                    bool isMaintenance = _userSerializeViewDataAppService.IsMaintenance(id);
                    if (userId != result.IdUser && isMaintenance)
                        return RedirectToAction("Maintenance", "AppView", new { id = id });
                }

                var doctorViewModel = new JavaScriptSerializer().Deserialize<IndexDoctorViewModelDeserialize>(result.Serialize);
                return View(doctorViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "DoctorBasicProTemplateController", "Index", id.ToString());
                return RedirectToAction("PageNotFound", "AppView");  
            }
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public async Task<ActionResult> AdminViewProfiles(int id = 0)
        {
            // Redirecionamento
            if (id == 0)
                return RedirectToAction("PageNotFound", "AppView");  

            try
            {
                var result = await _userSerializeViewDataAppService.GetBySiteNumberAsync(id, viewCod);

                if (result == null)
                    return RedirectToAction("PageNotFound", "AppView");  

                var doctorViewModel = new JavaScriptSerializer().Deserialize<IndexDoctorViewModelDeserialize>(result.Serialize);
                return View("Index", doctorViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "DoctorBasicProTemplateController", "AdminViewProfiles", id.ToString());
                return RedirectToAction("PageNotFound", "AppView");  
            }
        }
        
        [HttpPost]
        public JsonResult Serialize(int siteNumber = 0)
        {           
            try
            {
                string userId = User.Identity.GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new Exception();

                _indexDoctorViewModels.ExecuteViewModel(siteNumber);
                var serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(_indexDoctorViewModels);
                _userSerializeViewDataAppService.Persist(userId, siteNumber, viewCod, result);
                return Json("finalize", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "DoctorBasicProTemplateController", "Serialize", siteNumber.ToString());
                return Json("error" + ex.ToString(), JsonRequestBehavior.AllowGet);
            }  
        }

        [Authorize]
        public ActionResult Demo()
        {
            return View();
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}