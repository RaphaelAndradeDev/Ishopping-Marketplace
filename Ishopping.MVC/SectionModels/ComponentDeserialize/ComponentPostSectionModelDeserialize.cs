using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;

namespace Ishopping.MVC.SectionModels.ComponentDeserialize
{
    public class ComponentPostSectionModelDeserialize  
    {        
        public bool ItemActive { get; set; }
        public string ItemTitle { get; set; }
        public string ItemSubTitle { get; set; }
        public string ItemStTitle { get; set; }
        public string ItemStSubTitle { get; set; }
        public IEnumerable<ComponentPostSerialization> ListItens { get; set; }      
    }
}