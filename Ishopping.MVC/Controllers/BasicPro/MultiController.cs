using Ishopping.Application;
using Ishopping.Models;
using Ishopping.ViewModels.TemplateBasicPro;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ishopping.Controllers.BasicPro
{
    public class MultiController : Controller
    {
        private readonly IndexMultiViewModelSerialize _indexMultiViewModels;
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;
        const int viewCod = 3070;

        public MultiController(
            IndexMultiViewModelSerialize indexMultiViewModels,
            UserSerializeViewDataAppService userSerializeViewDataAppService)
        {
            _indexMultiViewModels = indexMultiViewModels;
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

                var multiViewModel = new JavaScriptSerializer().Deserialize<IndexMultiViewModelDeserialize>(result.Serialize);
                return View(multiViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MultiBasicProTemplateController", "Index", id.ToString());
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

                var multiViewModel = new JavaScriptSerializer().Deserialize<IndexMultiViewModelDeserialize>(result.Serialize);
                return View("Index", multiViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MultiBasicProTemplateController", "AdminViewProfiles", id.ToString());
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

                _indexMultiViewModels.ExecuteViewModel(siteNumber);
                var serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(_indexMultiViewModels);
                _userSerializeViewDataAppService.Persist(userId, siteNumber, viewCod, result);
                return Json("finalize", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MultiBasicProTemplateController", "Serialize", siteNumber.ToString());
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