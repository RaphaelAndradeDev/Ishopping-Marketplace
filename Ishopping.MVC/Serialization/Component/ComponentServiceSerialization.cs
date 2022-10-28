using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentServiceSerialization
    {
        public int Position { get;  set; }
        public string Title { get;  set; }        
        public string Description { get;  set; }

        // Relacionamentos       
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        public virtual ComponentServiceOptionSerialization ComponentServiceOption { get;  set; }        
    }
}
