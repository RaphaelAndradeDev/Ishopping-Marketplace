using Ishopping.Application;
using Ishopping.ViewModels.TemplateProfessional;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Script.Serialization;
using Ishopping.Models;
using System.Threading.Tasks;

namespace Ishopping.Controllers.Professional
{
    public class MaximaController : Controller
    {
        private readonly IndexMaximaViewModelSerialize _indexMaximaViewModel;
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;
        const int viewCod = 4060;

        public MaximaController(
            IndexMaximaViewModelSerialize indexMaximaViewModel,
            UserSerializeViewDataAppService userSerializeViewDataAppService)
        {        
            _indexMaximaViewModel = indexMaximaViewModel;
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

                var maximaViewModel = new JavaScriptSerializer().Deserialize<IndexMaximaViewModelDeserialize>(result.Serialize);
                return View(maximaViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MaximaProfessionalTemplateController", "Index", id.ToString());
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

                var maximaViewModel = new JavaScriptSerializer().Deserialize<IndexMaximaViewModelDeserialize>(result.Serialize);
                return View("Index", maximaViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MaximaProfessionalTemplateController", "AdminViewProfiles", id.ToString());
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

                _indexMaximaViewModel.ExecuteViewModel(siteNumber);
                var serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(_indexMaximaViewModel);
                _userSerializeViewDataAppService.Persist(userId, siteNumber, viewCod, result);
                return Json("finalize", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "MaximaProfessionalTemplateController", "Serialize", siteNumber.ToString());
                return Json("error" + ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult portfoliosingleslider()
        {
            return View();
        }

        public ActionResult blogsingle()
        {
            return View();
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