using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentFeaturesSerialization
    {        
        public string Title { get;  set; }
        public string Icon { get;  set; }
        public int Count { get;  set; }
        public string Description { get;  set; }

        //Relacionamentos
        public virtual ComponentFeaturesOptionSerialization ComponentFeaturesOption { get;  set; }        
    }
}
