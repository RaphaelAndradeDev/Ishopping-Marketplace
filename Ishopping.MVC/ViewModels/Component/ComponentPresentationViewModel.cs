using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentPresentationViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string VectorIcon { get; set; }

        // Get IsTags
        public string _Title { get; set; }
        public string _Description { get; set; }  

        // Relacionamentos       
        public Guid UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }

        public Guid ComponentPresentationOptionId { get; set; }
        public virtual ComponentPresentationOptionModel ComponentPresentationOption { get; set; }
    }

    public class ComponentPresentationOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}