using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentExtraLinkSerialization
    {      
        public string TextLink { get;  set; }       
        public string Link { get;  set; }
        public string Description { get;  set; }

        // Relacionamentos   
        public virtual ComponentExtraLinkOptionSerialization ComponentExtraLinkOption { get;  set; }        
    }
}
