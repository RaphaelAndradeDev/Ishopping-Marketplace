using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class AdminSliderController : Controller
    {
        private readonly IAdminSliderAppService _adminSlider;

        public AdminSliderController(IAdminSliderAppService adminSlider)
        {
            _adminSlider = adminSlider;
        }       

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Index(int id)
        {
            ViewBag.ViewDatasId = id;
            var adminSliderViewModel = Mapper.Map<IEnumerable<AdminSlider>, IEnumerable<AdminSliderViewModel>>(_adminSlider.GetAllByViewDataId(id));
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSliders = _adminSlider.GetById(id.Value);     
            if (adminSliders == null)
            {
                return HttpNotFound();
            }
            var adminSliderViewModel = Mapper.Map<AdminSlider, AdminSliderViewModel>(adminSliders);
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create(int id)
        {
            ViewBag.ViewDataId = id; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create(AdminSliderViewModel adminSliderViewModel)
        {
            int ViewDataId = adminSliderViewModel.AdminViewDataId;

            if (ModelState.IsValid)
            {
                var adminSlider = Mapper.Map<AdminSliderViewModel, AdminSlider>(adminSliderViewModel);
                _adminSlider.Add(adminSlider);
                return RedirectToAction("Index", new { id = ViewDataId});
            }
            ViewBag.ViewDatasId = ViewDataId; 
            return View(adminSliderViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSlider = _adminSlider.GetById(id.Value);           
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            var adminSliderViewModel = Mapper.Map<AdminSlider, AdminSliderViewModel>(adminSlider);
            return View(adminSliderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(AdminSliderViewModel adminSliderViewModel)
        {    
            if (ModelState.IsValid)
            {
                var adminSlider = Mapper.Map<AdminSliderViewModel, AdminSlider>(adminSliderViewModel);
                _adminSlider.Update(adminSlider);
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
            var adminSlider = _adminSlider.GetById(id.Value);       
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            var adminSliderViewModel = Mapper.Map<AdminSlider, AdminSliderViewModel>(adminSlider);
            return View(adminSliderViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminSlider = _adminSlider.GetById(id);
            _adminSlider.Remove(adminSlider);
            return RedirectToAction("Index", new { id = adminSlider.AdminViewDataId});
        }
    }
}
