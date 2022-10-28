using Ishopping.Mvc.Serialization.Option;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentPricingSerialization
    {
        public string NomePlano { get;  set; }
        public bool Destacar { get;  set; }
        public string Moeda { get;  set; }
        public string PriceUnid { get;  set; }
        public string PriceCent { get;  set; }
        public string Periodo { get;  set; }
        public string Description { get;  set; }
        public string Comment { get;  set; }
        public string TextButton { get;  set; }
        public string UrlButton { get;  set; }
        public string[] ListDescription { get { return Description.Split(','); } }
        public string Price { get { return PriceUnid + "," + PriceCent;} }
        public string PriceFull { get { return Moeda + " " + PriceUnid + "," + PriceCent; } }

        //Relacionamentos
        public virtual ComponentPricingOptionSerialization ComponentPricingOption { get;  set; }        
    }
}
