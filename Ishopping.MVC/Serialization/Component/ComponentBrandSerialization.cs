using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentBrandSerialization
    {     
        public string Marca { get;  set; }       
        public string Comment { get;  set; }
        public string SiteOficial { get;  set; }
        public int Exibicao { get;  set; }

        // Relacionamentos     
        public virtual UserImageGallerySerialization UserImageGallery { get;  set; }
        public virtual ComponentBrandOptionSerialization ComponentBrandOption { get;  set; }        
    }
}
