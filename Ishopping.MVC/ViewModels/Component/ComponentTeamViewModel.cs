using Ishopping.MVC.ViewModels.User;
using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentTeamViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string Name { get; set; }
        public string Functio { get; set; }
        public string Description { get; set; }

        // Get IsTags
        public string _Name { get; set; }
        public string _Functio { get; set; }
        public string _Description { get; set; }

        // Relacionamentos 
        public string UserImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }
        public Guid ComponentTeamOptionId { get; set; }
        public virtual ComponentTeamOptionModel ComponentTeamOption { get; set; }
        public virtual ICollection<ComponentTeamSocialNetworkViewModel> ComponentTeamSocialNetwork { get; set; }        
    }

    public class ComponentTeamOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Name { get; set; }
        public string Functio { get; set; }
        public string Description { get; set; }
    }
}
