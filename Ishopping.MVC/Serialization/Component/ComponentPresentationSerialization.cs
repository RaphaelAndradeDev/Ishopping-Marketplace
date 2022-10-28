using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentPresentationSerialization
    {
        public int Position { get;  set; }
        public string Title { get;  set; }     
        public string Category { get;  set; }
        public string Description { get;  set; }
        public string VectorIcon { get;  set; }

        // Relacionamentos       
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        public virtual ComponentPresentationOptionSerialization ComponentPresentationOption { get;  set; }        
    }
}
