using AutoMapper;
using Ishopping.Application;
using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
    public class AdminImageGalleryController : Controller
    {
        private readonly AdminViewDataAppService _adminViewData;
        private readonly AdminImageGalleryAppService _adminImageGallery;

        public AdminImageGalleryController(
            AdminViewDataAppService adminViewData,
            AdminImageGalleryAppService adminImageGallery)
        {
            _adminViewData = adminViewData;
            _adminImageGallery = adminImageGallery;
        }
       
        public ActionResult Index(int id)
        {                     
            const int fileType = 1;
            ViewBag.ViewDataId = id;
            ViewBag.views = _adminViewData.GetAllByTemplateId(id).Select(x => x.TextMenu).ToList();

            var all = _adminImageGallery.GetAllByViewDataId(id, fileType).OrderBy(x => x.Position).ToList();

            int p = all.Count(x => x.Position == 0);    // conta o número de imagens com posição = 0
            int t = all.Count();

            if (p > 0)                                  // se existe imagens com posição a serem marcadas
            {
                List<AdminImageGallery> alt = all.Where(x => x.Position == 0).ToList();      // cria uma lista com valores de posições que não existem ou seja posições = 0                                                                                  
                int m, n, a;
                a = 1;
                m = all.Max(x => x.Position);                                           // busca a maior posição
                if (p > m) n = p; else n = m;

                foreach (var j in alt)
                {
                    for (int i = a; i <= t; i++)
                    {
                        if (!all.Exists(x => x.Position == i))
                        {
                            j.Change(i); a = i; break;
                        }
                    }
                }
                if (ModelState.IsValid)
                {
                    _adminImageGallery.UpdateAll(all);
                    all = _adminImageGallery.GetAllByViewDataId(id, fileType).OrderBy(x => x.Position).ToList();
                }
            }
            var imageGallery = Mapper.Map<IEnumerable<AdminImageGallery>, IEnumerable<AdminImageGalleryViewModel>>(all);
            return View(imageGallery);
        }

        public ActionResult GetImgIcon(int id)
        {

            const int fileType = 2;
            ViewBag.ViewDataId = id;
            ViewBag.views = _adminViewData.GetAllByTemplateId(id).Select(x => x.TextMenu).ToList();

            var all = _adminImageGallery.GetAllByViewDataId(id, fileType).OrderBy(x => x.Position).ToList();

            int p = all.Count(x => x.Position == 0);    // conta o número de imagens com posição = 0
            int t = all.Count();

            if (p > 0)                                  // se existe imagens com posição a serem marcadas
            {
                List<AdminImageGallery> alt = all.Where(x => x.Position == 0).ToList();      // cria uma lista com valores de posições que não existem ou seja posições = 0                                                                                  
                int m, n, a;
                a = 1;
                m = all.Max(x => x.Position);                                           // busca a maior posição
                if (p > m) n = p; else n = m;

                foreach (var j in alt)
                {
                    for (int i = a; i <= t; i++)
                    {
                        if (!all.Exists(x => x.Position == i))
                        {
                            j.Change(i); a = i; break;
                        }
                    }
                }
                if (ModelState.IsValid)
                {
                    _adminImageGallery.UpdateAll(all);
                    all = _adminImageGallery.GetAllByViewDataId(id, fileType).OrderBy(x => x.Position).ToList();
                }
            }
            var imageGallery = Mapper.Map<IEnumerable<AdminImageGallery>, IEnumerable<AdminImageGalleryViewModel>>(all);
            return View(imageGallery);
        }

        public ActionResult GetImgLogo(int id)
        {
            const int fileType = 3;
            ViewBag.ViewDataId = id;
            ViewBag.views = _adminViewData.GetAllByTemplateId(id).Select(x => x.TextMenu).ToList();

            var all = _adminImageGallery.GetAllByViewDataId(id, fileType).OrderBy(x => x.Position).ToList();

            int p = all.Count(x => x.Position == 0);    // conta o número de imagens com posição = 0
            int t = all.Count();

            if (p > 0)                                  // se existe imagens com posição a serem marcadas
            {
                List<AdminImageGallery> alt = all.Where(x => x.Position == 0).ToList();      // cria uma lista com valores de posições que não existem ou seja posições = 0                                                                                  
                int m, n, a;
                a = 1;
                m = all.Max(x => x.Position);                                           // busca a maior posição
                if (p > m) n = p; else n = m;

                foreach (var j in alt)
                {
                    for (int i = a; i <= t; i++)
                    {
                        if (!all.Exists(x => x.Position == i))
                        {
                            j.Change(i); a = i; break;
                        }
                    }
                }
                if (ModelState.IsValid)
                {
                    _adminImageGallery.UpdateAll(all);
                    all = _adminImageGallery.GetAllByViewDataId(id, fileType).OrderBy(x => x.Position).ToList();
                }
            }
            var imageGallery = Mapper.Map<IEnumerable<AdminImageGallery>, IEnumerable<AdminImageGalleryViewModel>>(all);
            return View(imageGallery);
        }

        public ActionResult GetImgSlider(int id)
        {
            const int fileType = 16;
            ViewBag.ViewDataId = id;
            ViewBag.views = _adminViewData.GetAllByTemplateId(id).Select(x => x.TextMenu).ToList();
            var all = _adminImageGallery.GetAllByViewDataId(id, fileType).ToList();            
            var imageGallery = Mapper.Map<IEnumerable<AdminImageGallery>, IEnumerable<AdminImageGalleryViewModel>>(all);
            return View(imageGallery);
        }

        public void Edit(string p, int t, int id)
        {   
            int j = 1;

            var all = _adminImageGallery.GetAllByViewDataId(id, t).OrderBy(x => x.Position).ToList();

            string[] split = p.Split(new Char[] { ',' });

            foreach (var item in all)
            {
                item.Change(Convert.ToInt32(split[j++]));
            }

            if (ModelState.IsValid)
            {
                _adminImageGallery.UpdateAll(all);
            }

        }

        public ActionResult Delete(int folder, string fileName)
        {
            var ig = _adminImageGallery.GetByFileName(fileName);
            _adminImageGallery.Remove(ig);

            var filePath = Server.MapPath("~/Content/uploads/" + folder + "/" + fileName);
            int t = 1;
            int id = 0;
            string view = "Index";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);                             
                t = ig.FileType;
                id = ig.AdminViewDataId;                
            }

            var viewresult = Json(new { error = String.Empty });
            //for IE8 which does not accept application/json
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain";

            if (t == 1) { view = "Index"; }
            else if (t == 2) { view = "GetImgIcon"; }
            else { view = "GetImgProd"; }

            return RedirectToAction(view, new { id = id });
        }
    }
}