using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentScopeSerialization
    {   
        public int Position { get;  set; }
        public string Title { get;  set; }  
        public string Category { get;  set; }
        public string VectorIcon { get;  set; }
        public string Description { get;  set; }

        //Relacionamentos
        public virtual ComponentScopeOptionSerialization ComponentScopeOption { get;  set; }        
    }
}
