using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentClientViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string Name { get; set; }
        public string Functio { get; set; }
        public string Comment { get; set; }
        public string Projects { get; set; }
        public string SiteOficial { get; set; }

        // Get IsTags
        public string _Name { get; set; }
        public string _Functio { get; set; }
        public string _Comment { get; set; }
        public string _Projects { get; set; }  

        // Relacionamentos       
        public string UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }

        public Guid ComponentClientOptionId { get; set; }
        public virtual ComponentClientOptionModel ComponentClientOption { get; set; }
    }

    public class ComponentClientOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Name { get; set; }
        public string Functio { get; set; }
        public string Comment { get; set; }
        public string Projects { get; set; }
    }
}
