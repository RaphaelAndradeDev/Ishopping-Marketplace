using Ishopping.MVC.ViewModels.Admin;
using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Config
{
    public class ConfigUserView_ViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public bool Active { get; set; }
        public string TextMenu { get; set; }                            // Texto que aparecera no menu para esta view 

        // Relacionamento  -----------------------------------------
        public virtual ICollection<ConfigUserViewItem_ViewModel> ConfigUserViewItem { get; set; }
        public string AdminViewDataId { get; set; }
        public virtual AdminViewData_ViewModel AdminViewData { get; set; }
    }
}
