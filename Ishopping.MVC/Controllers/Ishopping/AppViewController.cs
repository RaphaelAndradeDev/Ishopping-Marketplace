using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.SectionModels.Ishopping;
using Ishopping.ViewModels.Ishopping;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers.Ishopping
{
    public class AppViewController : Controller
    {
        private readonly IAppViewAppService _appViewAppService;
        private readonly IConfigUserMaintenanceAppService _configUserMaintenance;
        private readonly IComponentPostAppService _componentPost;

        public AppViewController(
            IAppViewAppService appViewAppService,
            IConfigUserMaintenanceAppService configUserMaintenance,
            IComponentPostAppService componentPost)
        {
            _appViewAppService = appViewAppService;
            _configUserMaintenance = configUserMaintenance;
            _componentPost = componentPost;
        }


        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult Maintenance(int id = 0)
        {
            if(id == 0)
                return RedirectToAction("PageNotFound");  

            var userMaintenance = _configUserMaintenance.GetBySiteNumber(id);
            var maintenanceViewModel = Mapper.Map<ConfigUserMaintenance, MaintenanceViewModel>(userMaintenance);

            if (userMaintenance != null && userMaintenance.IsMaintenance)
                return View(maintenanceViewModel);

            if (userMaintenance != null && !userMaintenance.IsMaintenance)
                return RedirectToAction("Index", userMaintenance.Controller, new { id = id });

            return RedirectToAction("Index"); 
        }


        // Post Methods
        public async Task<JsonResult> GetTexto(string term)
        {
            var busca = await _componentPost.SearchAsync(term);
            return Json(busca, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Blog(int? siteNumber, string txtTexto, string category, int page = 1)
        {
            try
            {
                var postByView = await _componentPost.GetAllByViewsAsync(36);
                                
                ViewBag.Categorys = await _componentPost.GetAllCategoryAsync();
                ViewBag.TopViews = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<PostSummarySectionModel>>(postByView.Take(36)).ToList(), 8);
                ViewBag.PostSummary = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<PostSummarySectionModel>>(await _componentPost.GetAllByLastDateAsync(36)).ToList(), 3);

                if (siteNumber.HasValue)
                {
                    var blogViewModel = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<BlogViewModel>>(await _componentPost.GetAllBySiteNumberAsync(siteNumber.Value, 36)).ToList(), 36);
                    return View(blogViewModel.ToPagedList(page, 3));
                }

                if (!string.IsNullOrEmpty(txtTexto))
                {
                    var postList = await _componentPost.GetAllByTermAsync(txtTexto);
                    var blogViewModel = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<BlogViewModel>>(postList).ToList(), 36);
                    return View(blogViewModel.ToPagedList(page, 3));
                }

                if (!string.IsNullOrEmpty(category))
                {
                    var blogViewModel = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<BlogViewModel>>(await _componentPost.GetAllByCategoryAsync(category, 36)).ToList(), 36);
                    return View(blogViewModel.ToPagedList(page, 3));
                }
                else
                {
                    var blogViewModel = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<BlogViewModel>>(postByView).ToList(), 36);
                    return View(blogViewModel.ToPagedList(page, 3));
                }
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppViewController", "Blog", siteNumber.Value.ToString());
                return RedirectToAction("PageNotFound");  
            }
        }
                  
        public async Task<ActionResult> SinglePost(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("PageNotFound");  

            try
            {
                var singlePostViewModel = new SinglePostViewModel();
                ViewBag.Categorys = await _componentPost.GetAllCategoryAsync();                
                ViewBag.TopViews = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<PostSummarySectionModel>>(await _componentPost.GetAllByViewsAsync(36)).ToList(), 8);
                ViewBag.PostSummary = ShuffleList(Mapper.Map<IEnumerable<SimplePost>, IEnumerable<PostSummarySectionModel>>(await _componentPost.GetAllByLastDateAsync(36)).ToList(), 3);

                singlePostViewModel.SinglePost = Mapper.Map<SinglePost, SinglePostSectionModel>(await _componentPost.GetSinglePostByIdAsync(Guid.Parse(id)));

                if (singlePostViewModel.SinglePost.IsBlock)
                {
                    string userId = User.Identity.GetUserId();
                    if (singlePostViewModel.SinglePost.IdUser != userId)
                        return RedirectToAction("PageNotFound");                        
                }
                return View(singlePostViewModel);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppViewController", "SinglePost", id.ToString());
                return RedirectToAction("PageNotFound"); 
            }
        }
                            

        // Private Methods
        private List<T> ShuffleList<T>(List<T> sortList, int take)
        {
            Random rnd = new Random();
            var newList = new List<T>();
            var shuffleList = new List<T>();
            newList.AddRange(sortList);

            foreach (var item in sortList)
            {
                if (shuffleList.Count >= take)
                    break;

                int index = rnd.Next(0, newList.Count());
                shuffleList.Add(newList[index]);
                newList.RemoveAt(index);
            }
            return shuffleList;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}