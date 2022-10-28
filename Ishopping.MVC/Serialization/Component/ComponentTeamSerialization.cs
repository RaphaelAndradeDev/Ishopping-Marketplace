using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentTeamSerialization
    {  
        public string Name { get;  set; }    
        public string Functio { get;  set; }
        public string Description { get;  set; }
                
        // Relacionamentos 
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }                 
        public virtual ComponentTeamOptionSerialization ComponentTeamOption { get;  set; }
        public virtual ICollection<ComponentTeamSocialNetworkSerialization> ComponentTeamSocialNetwork { get; set; }

        
    }
}
