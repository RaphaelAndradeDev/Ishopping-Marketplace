using Ishopping.Mvc.Serialization.Option;
using System;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentFaqSerialization
    {        
        public int Position { get;  set; }
        public string Category { get;  set; }
        public string Pergunta { get;  set; }      
        public string Resposta { get;  set; }

        // Relacionamentos
        public virtual ComponentFaqOptionSerialization ComponentFaqOption { get;  set; }        
    }
}
