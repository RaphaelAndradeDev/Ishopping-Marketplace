using Ishopping.MVC.Models.Communs;

namespace Ishopping.MVC.ViewModels.Admin
{
    public class AdminSocialNetWorkViewModel : _SocialNetworkViewModel
    {
        public int Id { get; set; }
        public int AdminTemplateId { get; set; }
        public virtual AdminTemplateViewModel AdminTemplate { get; set; }
    }
}
