using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System.Collections.Generic;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentSimpleProductSerialization
    {      
        public string Name { get;  set; }   
        public string Category { get;  set; }
        public string Brand { get;  set; }
        public string Model { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }

        // Relacionamentos       
        public virtual ICollection<UserImageGallerySerialization> UserImageGallery { get; set; }
        public virtual ComponentSimpleProductOptionSerialization ComponentSimpleProductOption { get;  set; }
       
    }
}
