using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.ECommerce
{
    public class ECommerceProductGroupViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string grupo { get; set; }
        public int exibicao { get; set; }
        public virtual ICollection<ECommerceProductViewModel> ECommerceProduct { get; set; } 
    }
}
