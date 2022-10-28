using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentProjectSerialization
    {        
        public string Name { get;  set; }
        public string Title { get;  set; }     
        public DateTime DateIn { get;  set; }
        public string Client { get;  set; }
        public string Description { get;  set; }
        public string Category { get;  set; }
        public string WebSite { get;  set; }
        public string UrlVideo { get;  set; }
        public string Team { get;  set; }
             
        // Relacionamentos
        public virtual ICollection<UserImageGallerySerialization> UserImageGallery { get;  set; }
        public virtual ComponentProjectOptionSerialization ComponentProjectOption { get;  set; }        
    }
}
