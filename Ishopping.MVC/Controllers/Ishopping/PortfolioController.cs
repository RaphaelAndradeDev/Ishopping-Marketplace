using Ishopping.Application.Interface;
using Ishopping.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers.Ishopping
{
    public class PortfolioController : Controller
    {
        private readonly IAppPortfolioAppService _appPortfolioAppService;

        public PortfolioController(
            IAppPortfolioAppService appPortfolioAppService)
        {
            _appPortfolioAppService = appPortfolioAppService;  
        }

        public ActionResult Index()
        {
            return View();                      
        }               

        public async Task<ActionResult> ByCategory(string category)
        {
            try
            {
                var portfolio = await _appPortfolioAppService.GetAppPortfolioByCategoryAsync(category);
                return View(portfolio);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "ByCategory");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<ActionResult> ByTag(string tag)
        {
            try
            {
                var portfolio = await _appPortfolioAppService.GetAppPortfolioByTagAsync(tag);
                return View(portfolio);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "ByTag");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<PartialViewResult> GetResult(double lat = 0, double lon = 0)
        {
            try
            {
                var portfolio = await _appPortfolioAppService.GetAppPortfolioAsync();
                return PartialView("_PartialPortfolioResult", portfolio);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "GetResult");
                return PartialView("_PartialFailed");
            }
        }


        // Portfolio users
        public async Task<ActionResult> Main(int n)
        {
            try
            {
                var portfolio = await _appPortfolioAppService.GetAppPortfolioMainAsync(n);
                return View(portfolio);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "Users");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<ActionResult> Category(int n, string category)
        {
            try
            {
                var portfolio = await _appPortfolioAppService.GetAppPortfolioCategoryAsync(n, category);
                return View(portfolio);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "Category");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<ActionResult> SubCategory(int n, string category, string subCategory )
        {
            try
            {
                var portfolio = await _appPortfolioAppService.GetAppPortfolioSubCategoryAsync(n, category, subCategory);
                return View(portfolio);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "SubCategory");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        public async Task<ActionResult> Item(int n, string id)
        {
            try
            {
                Guid guid = new Guid();
                bool isGuid = Guid.TryParse(id, out guid);

                if(isGuid)
                {
                    var portfolio = await _appPortfolioAppService.GetAppPortfolioItemAsync(n, guid);
                    return View(portfolio);
                }
                else
                {
                    return RedirectToAction("PageNotFound", "AppView");
                }                
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "PortfolioController", "Item");
                return RedirectToAction("PageNotFound", "AppView");
            }
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}