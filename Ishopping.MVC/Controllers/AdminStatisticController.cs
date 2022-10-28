using Ishopping.Common.ConfigGlobal;
using Ishopping.Models;
using System;
using System.Web.Mvc;

namespace Ishopping.Controllers
{

    [Authorize(Roles = "AdminLevel1, AdminLevel2, AdminLevel3")]
    public class AdminStatisticController : Controller
    {
        public ActionResult GetLogError()
        {
            ViewBag.ServerTime = DateTime.Now;
            ViewBag.LocalTime = Timezone.DateTimeNow();
            ViewBag.LogError = LogError.ReaderError(GetPathToLogError());
            return View();
        }
               
        public ActionResult ClearLogError()
        {
            LogError.Clear(GetPathToLogError());
            return RedirectToAction("GetLogError");
        }

        // Private Methods
        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}