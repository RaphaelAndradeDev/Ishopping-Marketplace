using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentActivitySerialization
    {        
        public int Position { get;  set; }
        public string Title { get;  set; }     
        public string VectorIcon { get;  set; }
        public string Description { get;  set; }

        // Relacionamento
        public virtual ComponentActivityOptionSerialization ComponentActivityOption { get;  set; }        
    }
}
