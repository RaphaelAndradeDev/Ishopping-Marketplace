using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;

namespace Ishopping.MVC.SectionModels.ComponentDeserialize
{
    public class ComponentScopeSectionModelDeserialize 
    {        
        public bool ItemActive { get; set; }
        public string ItemTitle { get; set; }
        public string ItemSubTitle { get; set; }
        public string ItemStTitle { get; set; }
        public string ItemStSubTitle { get; set; }
        public IEnumerable<ComponentScopeSerialization> ListItens { get; set; }
        public string[,] Class { get; set; }
    }
}