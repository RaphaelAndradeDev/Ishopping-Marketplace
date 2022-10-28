using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class ViewDataController : Controller
    {
        private readonly IAdminViewDataAppService _adminViewData;

        public ViewDataController(IAdminViewDataAppService adminViewData)
        {
            _adminViewData = adminViewData;
        }
        
        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Index(int id)
        {
            ViewBag.templateId = id;
            var adminViewData = _adminViewData.GetAllByTemplateId(id);
            var adminViewDataViewModel = Mapper.Map<IEnumerable<AdminViewData>, IEnumerable<AdminViewData_ViewModel>>(adminViewData);
            return View(adminViewDataViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminViewData = _adminViewData.GetById(id.Value);
            int TemplateId = adminViewData.AdminTemplateId;
            if (adminViewData == null)
            {
                return HttpNotFound();
            }
            ViewBag.templateId = TemplateId;
            var adminViewDataViewModel = Mapper.Map<AdminViewData, AdminViewData_ViewModel>(adminViewData);
            return View(adminViewDataViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create(int id)
        {
            ViewBag.templateId = id; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create([Bind(Include = "Id,ViewCod,Controller,Action,OnMenu,ViewLink,ViewDefault,ClassActive,TextMenu,Active,ViewName,ViewTipo,Bloqueado,ExSlider,ExImg,AddSingle,ViewSingle,ListImage,ListIconPng,ListLogo,ListVectorIcon,ListText,ListList,NumBtn,NumVideo,AdminTemplateId")] AdminViewData_ViewModel adminViewDataViewModel)
        {
            int id = adminViewDataViewModel.AdminTemplateId;
            if (ModelState.IsValid)
            {
                var adminViewData = Mapper.Map<AdminViewData_ViewModel, AdminViewData>(adminViewDataViewModel);
                _adminViewData.Add(adminViewData);
                return RedirectToAction("Index", new { id = id });
            }
            ViewBag.templateId = id;
            return View(adminViewDataViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminViewData = _adminViewData.GetById(id.Value);
            int TemplateId = adminViewData.AdminTemplateId;

            if (adminViewData == null)
            {
                return HttpNotFound();
            }
            ViewBag.templateId = TemplateId;
            var adminViewDataViewModel = Mapper.Map<AdminViewData, AdminViewData_ViewModel>(adminViewData);
            return View(adminViewDataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit([Bind(Include = "Id,ViewCod,Controller,Action,OnMenu,ViewLink,ViewDefault,ClassActive,TextMenu,Active,ViewName,ViewTipo,Bloqueado,ExSlider,ExImg,AddSingle,ViewSingle,ListImage,ListIconPng,ListLogo,ListVectorIcon,ListText,ListList,NumBtn,NumVideo,AdminTemplateId")] AdminViewData_ViewModel adminViewDataViewModel)
        {
            int id = adminViewDataViewModel.AdminTemplateId;
            if (ModelState.IsValid)
            {
                var adminViewData = Mapper.Map<AdminViewData_ViewModel, AdminViewData>(adminViewDataViewModel);
                _adminViewData.Update(adminViewData);
                return RedirectToAction("Index", new { id = id });
            }

            ViewBag.templateId = id;
            return View(adminViewDataViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminViewData = _adminViewData.GetById(id.Value);
            int TemplateId = adminViewData.AdminTemplateId;

            if (adminViewData == null)
            {
                return HttpNotFound();
            }

            ViewBag.templateId = TemplateId;
            var adminViewDataViewModel = Mapper.Map<AdminViewData, AdminViewData_ViewModel>(adminViewData);
            return View(adminViewDataViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult DeleteConfirmed(int id)
        {
            var viewData = _adminViewData.GetById(id);
            _adminViewData.Remove(viewData);
            return RedirectToAction("Index", new { id = viewData.AdminTemplateId});
        }       
    }
}
