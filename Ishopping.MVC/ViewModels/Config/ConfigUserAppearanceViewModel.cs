using Ishopping.MVC.Models.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Config
{
    public class ConfigUserAppearanceViewModel 
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string StyleName { get; set; }
        public virtual ICollection<ConfigUserStyleColorViewModel> ConfigUserStyleColor { get; set; }
    }
}
