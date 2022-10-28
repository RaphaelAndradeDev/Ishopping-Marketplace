using Ishopping.MVC.Models.Communs;

namespace Ishopping.MVC.ViewModels.Admin
{
    public class AdminAppearanceViewModel : _AppearanceViewModel
    { 
        public int AdminTemplateId { get; set; }
        public virtual AdminTemplateViewModel AdminTemplateViewModel { get; set; }
    }
}
