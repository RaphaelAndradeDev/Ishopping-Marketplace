using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentSummarySerialization
    {
        public int Position { get;  set; }
        public string Title { get;  set; }   
        public string Category { get;  set; }
        public string Description { get;  set; }

        //Relacionamentos       
        public virtual ComponentSummaryOptionSerialization ComponentSummaryOption { get;  set; }      
    }
}
