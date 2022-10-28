using Ishopping.Domain.Entities;
using Ishopping.MVC.ViewModels.Admin;
using System;

namespace Ishopping.MVC.ViewModels.Config
{
    public class ConfigUserViewItem_ViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public bool Active { get; set; }                                // Ativar este item.                                 
        public string TextMenu { get; set; }                            // Texto que aparecera no menu para esta viewItem
        public string TextView { get; set; }                            // Texto que aparecera na view
        public string SubTitle { get; set; }                            // Texto que aparecera na view 

        // Relacionamentos ----------------------------
        public virtual ConfigUserView_ViewModel ConfigUserView { get; set; }
        public string AdminViewItemId { get; set; }
        public virtual AdminViewItem_ViewModel AdminViewItem { get; set; }       
    }
}
