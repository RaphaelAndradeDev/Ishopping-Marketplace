using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.ECommerce
{
    public class ECommerceProductCategoryViewModel
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string categoria { get; set; }
        public int exibicao { get; set; }
        public virtual IEnumerable<ECommerceProductViewModel> ECommerceProduct { get; set; }  
    }
}
