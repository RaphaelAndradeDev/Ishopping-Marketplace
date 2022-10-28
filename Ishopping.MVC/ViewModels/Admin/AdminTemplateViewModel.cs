using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Admin
{
    public class AdminTemplateViewModel
    {
        public int Id { get; set; }
        public int TemplateCod { get; set; }                    // identificação única
        public string Name { get; set; }
        public int Group { get; set; }
        public string CssPath { get; set; }                     // se for mais de 1 então separar por virgula
        public virtual AdminAppearanceViewModel AdminAppearance { get; set; }
        public virtual ICollection<AdminSocialNetWorkViewModel> AdminSocialNetWork { get; set; }
        public virtual ICollection<AdminViewData_ViewModel> AdminViewData { get; set; }
    }
}
