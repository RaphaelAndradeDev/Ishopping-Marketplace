using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentSkillSerialization
    {  
        public int Position { get;  set; }
        public string Category { get;  set; }
        public string Description { get;  set; }
        public int Level { get;  set; }


        //Relacionamentos
        public virtual ComponentSkillOptionSerialization ComponentSkillOption { get;  set; }
        
    }
}
