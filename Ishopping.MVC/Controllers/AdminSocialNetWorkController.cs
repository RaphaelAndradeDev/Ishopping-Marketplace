using AutoMapper;
using Ishopping.Application;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class AdminSocialNetWorkController : Controller
    {
        private readonly AdminSocialNetWorkAppService _adminSocialNetWork;

        public AdminSocialNetWorkController(AdminSocialNetWorkAppService adminSocialNetWork)
        {
            _adminSocialNetWork = adminSocialNetWork;
        }
       
        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Index(int id)
        {
            ViewBag.templateId = id;
            var adminSocialNetwork = _adminSocialNetWork.GetAllByTemplateId(id);
            var adminSocialNetworkViewModel = Mapper.Map<IEnumerable<AdminSocialNetWork>, IEnumerable<AdminSocialNetWorkViewModel>>(adminSocialNetwork);
            return View(adminSocialNetworkViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSocialNetWork = _adminSocialNetWork.GetById(id.Value);
            if (adminSocialNetWork == null)
            {
                return HttpNotFound();
            }
            var adminSocialNetworkViewModel = Mapper.Map<AdminSocialNetWork, AdminSocialNetWorkViewModel>(adminSocialNetWork);
            return View(adminSocialNetworkViewModel);
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
        public ActionResult Create([Bind(Include = "Id,AdminTemplateId,Rede,Classe1,Classe2,Classe3,Classe4")] AdminSocialNetWorkViewModel adminSocialNetworkViewModel)
        {
            int templateId = adminSocialNetworkViewModel.AdminTemplateId;

            if (ModelState.IsValid)
            {
                var adminSocialNetWork = Mapper.Map<AdminSocialNetWorkViewModel, AdminSocialNetWork>(adminSocialNetworkViewModel);
                _adminSocialNetWork.Add(adminSocialNetWork);
                return RedirectToAction("Index", new { id = templateId });
            }

            ViewBag.templateId = templateId; 
            return View(adminSocialNetworkViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSocialNetWork = _adminSocialNetWork.GetById(id.Value);
            if (adminSocialNetWork == null)
            {
                return HttpNotFound();
            }
            var adminSocialNetworkViewModel = Mapper.Map<AdminSocialNetWork, AdminSocialNetWorkViewModel>(adminSocialNetWork);
            return View(adminSocialNetworkViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit([Bind(Include = "Id,AdminTemplateId,Rede,Classe1,Classe2,Classe3,Classe4")] AdminSocialNetWorkViewModel adminSocialNetworkViewModel)
        {
            if (ModelState.IsValid)
            {
                var adminSocialNetWork = Mapper.Map<AdminSocialNetWorkViewModel, AdminSocialNetWork>(adminSocialNetworkViewModel);
                _adminSocialNetWork.Update(adminSocialNetWork);
                return RedirectToAction("Index", new { id = adminSocialNetWork.AdminTemplateId });
            }
            return View(adminSocialNetworkViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSocialNetWork = _adminSocialNetWork.GetById(id.Value);
            if (adminSocialNetWork == null)
            {
                return HttpNotFound();
            }
            var adminSocialNetworkViewModel = Mapper.Map<AdminSocialNetWork, AdminSocialNetWorkViewModel>(adminSocialNetWork);
            return View(adminSocialNetworkViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminSocialNetWork = _adminSocialNetWork.GetById(id);
            _adminSocialNetWork.Remove(adminSocialNetWork);
            return RedirectToAction("Index", new { id = adminSocialNetWork.AdminTemplateId });
        }
    }
}
