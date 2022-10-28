using Ishopping.Common.ConfigGlobal;
using System;

namespace Ishopping.MVC.ViewModels.Config
{
    public class ConfigUserMaintenanceViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public bool IsMaintenance { get; set; }
        public string ViewName { get; set; }
        public string PartialView { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateReturn { get; set; }   
        
        public DateTime _DateReturn { get { return Timezone.ThisDateTime(DateReturn); } }
    }
}
