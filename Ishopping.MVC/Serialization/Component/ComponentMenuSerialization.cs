using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentMenuSerialization
    {        
        public string Category { get;  set; }
        public string Title { get;  set; }       
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public bool IsDynamic { get;  set; }
        public string DayOfWeek { get;  set; }

        // Relacionamentos       
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        public virtual ComponentMenuOptionSerialization ComponentMenuOption { get;  set; }        
    }
}
