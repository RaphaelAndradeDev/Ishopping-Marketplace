using Ishopping.MVC.Models.Communs;
using System;

namespace Ishopping.MVC.ViewModels.Config
{
    public class ConfigUserStyleColorViewModel
    {
        public Guid Id { get; set; }
        public string DefaultColor { get; set; }
        public string UserColor { get; set; }

        public Guid ConfigUserAppearanceId { get; set; }
        public virtual ConfigUserAppearanceViewModel ConfigUserAppearance { get; set; }
    }
}
