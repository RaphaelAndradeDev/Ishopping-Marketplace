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
    public class SpiritController : Controller
    {
        private readonly IndexSpiritViewModelSerialize _indexSpiritViewModels;
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;
        const int viewCod = 3060;

        public SpiritController(
            IndexSpiritViewModelSerialize indexSpiritViewModels,
            UserSerializeViewDataAppService userSerializeViewDataAppService)
        {
            _indexSpiritViewModels = indexSpiritViewModels;
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

                var spiritViewModel = new JavaScriptSerializer().Deserialize<IndexSpiritViewModelDeserialize>(result.Serialize);
                return View(spiritViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SpiritBasicProTemplateController", "Index", id.ToString());
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

                var spiritViewModel = new JavaScriptSerializer().Deserialize<IndexSpiritViewModelDeserialize>(result.Serialize);
                return View("Index", spiritViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SpiritBasicProTemplateController", "AdminViewProfiles", id.ToString());
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

                _indexSpiritViewModels.ExecuteViewModel(siteNumber);
                var serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(_indexSpiritViewModels);
                _userSerializeViewDataAppService.Persist(userId, siteNumber, viewCod, result);
                return Json("finalize", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "SpiritBasicProTemplateController", "Serialize", siteNumber.ToString());
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