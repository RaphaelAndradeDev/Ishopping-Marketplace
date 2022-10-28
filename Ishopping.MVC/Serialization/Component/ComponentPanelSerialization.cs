using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentPanelSerialization
    {        
        public int Position { get;  set; }
        public string Icon { get;  set; }
        public string Title { get;  set; }        
        public string Text { get;  set; }    
  
        //Relacionamentos
        public virtual ComponentPanelOptionSerialization ComponentPanelOption { get;  set; }        
    }
}
