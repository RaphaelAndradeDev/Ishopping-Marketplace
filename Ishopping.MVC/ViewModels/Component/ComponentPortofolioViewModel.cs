using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentPortofolioViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool DisplayOnPage { get; set; }
        public bool DisplayOnlyPage { get; set; }
        public bool PortfolioHead { get; set; }
        public bool PortfolioChild { get; set; }
        public int SiteNumber { get; set; }
        public int Position { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string List { get; set; }
        public bool Ordered { get; set; }           // lista ordenada = true, não ordenada = false

        // Get IsTags
        public string _Tags { get; set; }
        public string _Title { get; set; }
        public string _Description { get; set; }
        public string _List { get; set; }  

        // Relacionamentos     
        public string UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }

        public Guid ComponentPortofolioOptionId { get; set; }
        public virtual ComponentPortofolioOptionModel ComponentPortofolioOption { get; set; }
    }

    public class ComponentPortofolioOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string List { get; set; }
    }
}
