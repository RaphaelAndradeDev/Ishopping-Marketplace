using Ishopping.Application.Interface;
using Ishopping.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers.Ishopping
{
    public class StoreController : Controller
    {
        private readonly IAppStoreAppService _appStoreAppService;

        public StoreController(IAppStoreAppService appStoreAppService)
        {
            _appStoreAppService = appStoreAppService;
        }

        public ActionResult Index()
        {
            return View(_appStoreAppService.GetAppStore());
        }

        public ActionResult Filter(string term, int? category, int? subCategory)
        {
            return View(_appStoreAppService.GetAppStore(term, category, subCategory));
        }

        // Buscas
        public async Task<JsonResult> Search(string siteNumber, string term)
        {
            try
            {
                var result = await _appStoreAppService.SearchAsync(siteNumber, term);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "Search");
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        // Carregamento de dados da página     
        public async Task<JsonResult> GetDataPage(double lat, double lon, string storeFilter)
        {
            try
            {
                var dataPage = await _appStoreAppService.GetDataPageAsync(lat, lon, storeFilter);           
                return Json(dataPage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetResult");
                return Json("Error");
            }
        }

        // Carregamento da página Filter com filtros        
        public async Task<JsonResult> GetDataPageByParameters(string dataPage, string storeFilter)
        {
            try
            {
                var result = await _appStoreAppService.GetAppStoreByParametersAsync(dataPage, storeFilter);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetDataPageByParameters");
                return Json("Error");
            }
        }


        // Carregamento da página Index
        public async Task<PartialViewResult> GetProductT1(string productId, int page, int lenght)
        {
            try
            {
                var store = await _appStoreAppService.GetProductT1Async(productId, page, lenght);
                return PartialView("_PartialProductT1", store);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetProductT1");
                return PartialView("_PartialFailed");
            }
        }

        public async Task<PartialViewResult> GetProductT2(string siteNumber, string category)
        {
            try
            {
                var store = await _appStoreAppService.GetProductT2Async(siteNumber, category);
                return PartialView("_PartialProductT2", store);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetProductT2");
                return PartialView("_PartialFailed");
            }
        }

        public PartialViewResult GetProductT4(string category)
        {
            try
            {
                var store = _appStoreAppService.GetProductT4Async(category);
                return PartialView("_PartialProductT4", store);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetProductT2");
                return PartialView("_PartialFailed");
            }
        }


        // Carregamento da página Filter   
        public PartialViewResult LoadPartialPageFilter(string dataFilter)
        {
            try
            {
                var result = _appStoreAppService.GetPartialPageFilterAsync(dataFilter);
                return PartialView("_PartialPageFilter", result);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetProductT3");
                return PartialView("_PartialFailed");
            }
        }        

        public async Task<PartialViewResult> GetProductT3(string productId, int page, int lenght, int sortBy = 3)
        {
            try
            {
                var store = await _appStoreAppService.GetProductT3Async(productId, page, lenght, sortBy);
                return PartialView("_PartialProductT3", store);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetProductT3");
                return PartialView("_PartialFailed");
            }
        }


        


        // Store users
        public async Task<ActionResult> Main(int n)
        {
            try
            {
                var store = await _appStoreAppService.GetAppStoreMainAsync(n);
                return View(store);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "Main");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<ActionResult> Item(int n, string id)
        {
            try
            {
                Guid guid = new Guid();
                bool isGuid = Guid.TryParse(id, out guid);

                if (isGuid)
                {
                    var store = await _appStoreAppService.GetAppStoreItemAsync(n, guid);
                    return View(store);
                }
                else
                {
                    return RedirectToAction("PageNotFound", "AppView");
                }                
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "Item");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<JsonResult> GetListProductId(int siteNumber)
        {
            try
            {
                var productId = await _appStoreAppService.GetListProductIdAsync(siteNumber);
                return Json(productId, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "StoreController", "GetResult");
                return Json("Error");
            }
        }

        // Private Methods
        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}