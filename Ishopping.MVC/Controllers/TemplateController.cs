using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class TemplateController : Controller
    {
        private readonly IAdminTemplateAppService _adminTemplate;

        public TemplateController(IAdminTemplateAppService adminTemplate)
        {
            _adminTemplate = adminTemplate;
        }
       
        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Index()
        {
            var adminTemplateViewModel = Mapper.Map<IEnumerable<AdminTemplate>, IEnumerable<AdminTemplateViewModel>>(_adminTemplate.GetAll());
            return View(adminTemplateViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var admintemplate = _adminTemplate.GetById(id.Value);
            if (admintemplate == null)
            {
                return HttpNotFound();
            }
            var adminTemplateViewModel = Mapper.Map<AdminTemplate, AdminTemplateViewModel>(admintemplate);
            return View(adminTemplateViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Create([Bind(Include = "Id,TemplateCod,Name,Group")] AdminTemplateViewModel adminTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                var adminTemplate = Mapper.Map<AdminTemplateViewModel, AdminTemplate>(adminTemplateViewModel);
                _adminTemplate.Add(adminTemplate);
                return RedirectToAction("Index");
            }
            return View(adminTemplateViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var admintemplate = _adminTemplate.GetById(id.Value);
            if (admintemplate == null)
            {
                return HttpNotFound();
            }
            var adminTemplateViewModel = Mapper.Map<AdminTemplate, AdminTemplateViewModel>(admintemplate);
            return View(adminTemplateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit([Bind(Include = "Id,TemplateCod,Name,Group")] AdminTemplateViewModel adminTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                var adminTemplate = Mapper.Map<AdminTemplateViewModel, AdminTemplate>(adminTemplateViewModel);
                _adminTemplate.Update(adminTemplate);
                return RedirectToAction("Index");
            }           
            return View(adminTemplateViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var admintemplate = _adminTemplate.GetById(id.Value);
            if (admintemplate == null)
            {
                return HttpNotFound();
            }
            var adminTemplateViewModel = Mapper.Map<AdminTemplate, AdminTemplateViewModel>(admintemplate);
            return View(adminTemplateViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult DeleteConfirmed(int id)
        {
            var template = _adminTemplate.GetById(id);
            _adminTemplate.Remove(template);
            return RedirectToAction("Index");
        }
    }
}
