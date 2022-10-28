using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentClientSerialization
    {        
        public string Name { get;  set; }       
        public string Functio { get;  set; }
        public string Comment { get;  set; }
        public string Projects { get;  set; }
        public string SiteOficial { get;  set; }

        // Relacionamentos       
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        public virtual ComponentClientOptionSerialization ComponentClientOption { get;  set; }        
    }
}
