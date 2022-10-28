using System.Linq;

namespace Ishopping.Domain.ApplicationClass
{
    public class BasicProfile
    {
        public int SiteNumber { get; set; }
        public string Controller { get; set; }
        public string AppMenu { get; set; }
        public int TemplateCod { get; set; }
        public int ViewStart { get; set; }
        public bool Serialize { get; set; }
        public string GoogleFonts { get; set; }        

        public bool ExistItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                return false;

            else if (item == "ever")
                return true;

            var itens = this.AppMenu.Split(',');
            return itens.Any(x => x == item);
        }
    }
}
