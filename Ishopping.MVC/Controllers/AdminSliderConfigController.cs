using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class AdminSliderConfigController : Controller
    {
        private readonly IAdminSliderConfigAppService _adminSliderConfig;

        public AdminSliderConfigController(IAdminSliderConfigAppService adminSliderConfig)
        {
            _adminSliderConfig = adminSliderConfig;
        }       

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Index(int id)
        {
            ViewBag.ViewDatasId = id;
            var adminSliderViewModel = Mapper.Map<IEnumerable<AdminSliderConfig>, IEnumerable<AdminSliderConfigViewModel>>(_adminSliderConfig.GetAllByViewDataId(id));
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSliders = _adminSliderConfig.GetById(id.Value);     
            if (adminSliders == null)
            {
                return HttpNotFound();
            }
            var adminSliderViewModel = Mapper.Map<AdminSliderConfig, AdminSliderConfigViewModel>(adminSliders);
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create(int id)
        {
            ViewBag.ViewDatasId = id; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create(AdminSliderConfigViewModel adminSliderViewModel)
        {
            int ViewDatasId = adminSliderViewModel.AdminViewDataId;

            if (ModelState.IsValid)
            {
                var adminSlider = Mapper.Map<AdminSliderConfigViewModel, AdminSliderConfig>(adminSliderViewModel);
                _adminSliderConfig.Add(adminSlider);
                return RedirectToAction("Index", new { id = ViewDatasId});
            }
            ViewBag.ViewDatasId = ViewDatasId; 
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSlider = _adminSliderConfig.GetById(id.Value);           
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            var adminSliderViewModel = Mapper.Map<AdminSliderConfig, AdminSliderConfigViewModel>(adminSlider);
            return View(adminSliderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(AdminSliderConfigViewModel adminSliderViewModel)
        {    
            if (ModelState.IsValid)
            {
                var adminSlider = Mapper.Map<AdminSliderConfigViewModel, AdminSliderConfig>(adminSliderViewModel);
                _adminSliderConfig.Update(adminSlider);
                return RedirectToAction("Index", new { id = adminSlider.AdminViewDataId });
            }
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSlider = _adminSliderConfig.GetById(id.Value);       
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            var adminSliderViewModel = Mapper.Map<AdminSliderConfig, AdminSliderConfigViewModel>(adminSlider);
            return View(adminSliderViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminSlider = _adminSliderConfig.GetById(id);
            _adminSliderConfig.Remove(adminSlider);
            return RedirectToAction("Index", new { id = adminSlider.AdminViewDataId});
        }
    }
}
