using Ishopping.Application;
using Ishopping.ViewModels.TemplateBasic;
using System;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Ishopping.Models;
using System.Threading.Tasks;

namespace Ishopping.Controllers.Basic
{
    public class ShieldController : Controller
    {
        private readonly IndexShieldViewModelSerialize _indexShieldViewModels;
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;
        const int viewCod = 2060;

        public ShieldController(
            IndexShieldViewModelSerialize indexShieldViewModels,
            UserSerializeViewDataAppService userSerializeViewDataAppService)
        {
            _indexShieldViewModels = indexShieldViewModels;
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

                var shieldViewModel = new JavaScriptSerializer().Deserialize<IndexShieldViewModelDeserialize>(result.Serialize);
                return View(shieldViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ShieldBasicTemplateController", "Index", id.ToString());
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

                var shieldViewModel = new JavaScriptSerializer().Deserialize<IndexShieldViewModelDeserialize>(result.Serialize);
                return View("Index", shieldViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ShieldBasicTemplateController", "AdminViewProfiles", id.ToString());
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

                _indexShieldViewModels.ExecuteViewModel(siteNumber);
                var serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(_indexShieldViewModels);
                _userSerializeViewDataAppService.Persist(userId, siteNumber, viewCod, result);
                return Json("finalize", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ShieldBasicTemplateController", "Serialize", siteNumber.ToString());
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