using Ishopping.Application;
using Ishopping.ViewModels.TemplateBasicPro;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Script.Serialization;
using Ishopping.Models;
using System.Threading.Tasks;

namespace Ishopping.Controllers.BasicPro
{
    public class HimuController : Controller
    {
        private readonly IndexHimuViewModelSerialize _indexHimuViewModels;
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;
        const int viewCod = 3040;

        public HimuController(
            IndexHimuViewModelSerialize indexHimuViewModels,
            UserSerializeViewDataAppService userSerializeViewDataAppService)
        {
            _indexHimuViewModels = indexHimuViewModels;
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

                var himuViewModel = new JavaScriptSerializer().Deserialize<IndexHimuViewModelDeserialize>(result.Serialize);
                return View(himuViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HimuBasicProTemplateController", "Index", id.ToString());
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

                var himuViewModel = new JavaScriptSerializer().Deserialize<IndexHimuViewModelDeserialize>(result.Serialize);
                return View("Index", himuViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HimuBasicProTemplateController", "AdminViewProfiles", id.ToString());
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

                _indexHimuViewModels.ExecuteViewModel(siteNumber);
                var serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(_indexHimuViewModels);
                _userSerializeViewDataAppService.Persist(userId, siteNumber, viewCod, result);
                return Json("finalize", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "HimuBasicProTemplateController", "Serialize", siteNumber.ToString());
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