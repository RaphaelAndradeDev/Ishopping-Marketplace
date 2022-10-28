using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentBrandViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string marca { get; set; }
        public string Comment { get; set; }
        public string SiteOficial { get; set; }
        public int exibicao { get; set; }

        // Get IsTags
        public string _Marca { get; set; }
        public string _Comment { get; set; }  

        // Relacionamentos     
        public string UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }

        public Guid ComponentBrandOptionId { get; set; }
        public virtual ComponentBrandOptionModel ComponentBrandOption { get; set; }
    }

    public class ComponentBrandOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Marca { get; set; }
        public string Comment { get; set; }
    }
}
