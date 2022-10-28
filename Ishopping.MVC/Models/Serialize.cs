
/* Use com o script DataSerialize para serializar os dados em qualquer view */

namespace Ishopping.Models
{
    public class Serialize
    {
        public int SiteNumber { get; private set; }
        public string Controller { get; private set; }        
        public bool IsSerialize { get; private set; }

        public Serialize(int siteNumber, string controller, bool isSerialize)
        {
            this.SiteNumber = siteNumber;
            this.Controller = controller;
            this.IsSerialize = isSerialize;
        }
    }
}