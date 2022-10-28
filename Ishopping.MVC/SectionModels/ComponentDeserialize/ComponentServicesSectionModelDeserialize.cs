﻿using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;

namespace Ishopping.MVC.SectionModels.ComponentDeserialize
{
    public class ComponentServiceSectionModelDeserialize
    {       
        public bool ItemActive { get; set; }
        public string ItemTitle { get; set; }
        public string ItemSubTitle { get; set; }
        public string ItemStTitle { get; set; }
        public string ItemStSubTitle { get; set; }
        public IEnumerable<ComponentServiceSerialization> ListItens { get; set; }
    }
}