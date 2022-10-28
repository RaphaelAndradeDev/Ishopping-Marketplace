using AutoMapper;
using Ishopping.Application;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    public class AdminViewItensController : Controller
    {
        private readonly AdminViewItemAppService _adminViewItem;

        public AdminViewItensController(AdminViewItemAppService adminViewItem)
        {
            _adminViewItem = adminViewItem;
        }
       
        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Index(int id)
        {
            ViewBag.ViewDatasId = id;
            var adminViewItem = _adminViewItem.GetAllByViewDataId(id);
            var adminViewItemViewModel = Mapper.Map<IEnumerable<AdminViewItem>, IEnumerable<AdminViewItem_ViewModel>>(adminViewItem);
            return View(adminViewItemViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminViewItem = _adminViewItem.GetById(id.Value);
            if (adminViewItem == null)
            {
                return HttpNotFound();
            }
            var adminViewItemViewModel = Mapper.Map<AdminViewItem, AdminViewItem_ViewModel>(adminViewItem);
            return View(adminViewItemViewModel);
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
        public ActionResult Create([Bind(Include = "Id,OnMenu,Active,TextMenu,TextView,ViewTipo,Link,AdminViewDataId")] AdminViewItem_ViewModel adminViewItemViewModel)
        {
            int ViewDatasId = adminViewItemViewModel.Id;

            if (ModelState.IsValid)
            {
                var adminViewItem = Mapper.Map<AdminViewItem_ViewModel, AdminViewItem>(adminViewItemViewModel);
                _adminViewItem.Add(adminViewItem);
                return RedirectToAction("Index", new { id = ViewDatasId});
            }

            ViewBag.ViewDatasId = ViewDatasId;
            return View(adminViewItemViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminViewItem = _adminViewItem.GetById(id.Value);
            if (adminViewItem == null)
            {
                return HttpNotFound();
            }
            var adminViewItemViewModel = Mapper.Map<AdminViewItem, AdminViewItem_ViewModel>(adminViewItem);
            return View(adminViewItemViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Edit([Bind(Include = "Id,OnMenu,Active,TextMenu,TextView,ViewTipo,Link,AdminViewDataId")] AdminViewItem_ViewModel adminViewItemViewModel)
        {          
            if (ModelState.IsValid)
            {
                var adminViewItem = Mapper.Map<AdminViewItem_ViewModel, AdminViewItem>(adminViewItemViewModel);
                _adminViewItem.Update(adminViewItem);
                return RedirectToAction("Index", new { id = adminViewItem.Id });
            }
            return View(adminViewItemViewModel);
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminViewItem = _adminViewItem.GetById(id.Value);
            if (adminViewItem == null)
            {
                return HttpNotFound();
            }
            var adminViewItemViewModel = Mapper.Map<AdminViewItem, AdminViewItem_ViewModel>(adminViewItem);
            return View(adminViewItemViewModel);
        }
               
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminViewItens = _adminViewItem.GetById(id);
            _adminViewItem.Remove(adminViewItens);
            return RedirectToAction("Index", new { id = adminViewItens.Id});
        }       
    }
}
