using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentPortofolioSerialization
    {        
        public int Position { get;  set; }
        public string Category { get;  set; }
        public string Title { get;  set; }        
        public string Description { get;  set; }
        public string List { get;  set; }
        public bool Ordered { get;  set; }           // lista ordenada = true, não ordenada = false


        // Relacionamentos        
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        public virtual ComponentPortofolioOptionSerialization ComponentPortofolioOption { get;  set; }       
    }
}
