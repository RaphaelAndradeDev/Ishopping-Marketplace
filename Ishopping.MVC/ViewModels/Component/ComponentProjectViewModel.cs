using Ishopping.MVC.ViewModels.User;
using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentProjectViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime DateIn { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string WebSite { get; set; }
        public string UrlVideo { get; set; }
        public string Team { get; set; }

        // Get IsTags
        public string _Title { get; set; }
        public string _Description { get; set; }
        public string _Name { get; set; }
        public string _Client { get; set; }

        // Relacionamentos
        public virtual ICollection<UserImageGalleryViewModel> UserImageGallery { get; set; }

        public Guid ComponentProjectOptionId { get; set; }
        public virtual ComponentProjectOptionModel ComponentProjectOption { get; set; }
    }

    public class ComponentProjectOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Team { get; set; }
    }
}
