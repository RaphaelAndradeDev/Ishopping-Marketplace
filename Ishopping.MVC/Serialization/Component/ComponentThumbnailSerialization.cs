using Ishopping.Mvc.Serialization.User;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentThumbnailSerialization
    {    
        public string Category { get;  set; }
        public string VectorIcon { get;  set; }
        public string WebSite { get; set; }

        // Relacionamentos       
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        
    }
}
