using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentServiceViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Get IsTags
        public string _Title { get; set; }
        public string _Description { get; set; }  

        // Relacionamentos       
        public string UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }

        public Guid ComponentServiceOptionId { get; set; }
        public virtual ComponentServiceOptionModel ComponentServiceOption { get; set; }
    }

    public class ComponentServiceOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
