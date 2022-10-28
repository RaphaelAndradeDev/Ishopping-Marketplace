using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentMenuViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDynamic { get; set; }
        public string DayOfWeek { get; set; }

        // Get IsTags
        public string _Title { get; set; }
        public string _Description { get; set; }  

        // Relacionamentos       
        public string UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }

        public Guid ComponentMenuOptionId { get; set; }
        public virtual ComponentMenuOptionModel ComponentMenuOption { get; set; }
    }

    public class ComponentMenuOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
