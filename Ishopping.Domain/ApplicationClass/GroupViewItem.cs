

namespace Ishopping.Domain.ApplicationClass
{
    public class GroupViewItem 
    {
        public string Id { get; set; }
        public bool Active { get; set; }                                                       
        public string TextMenu { get; set; }
        public string AdmTextMenu { get; set; }
        public string TextMenuCl { get { return SetClass(AdmTextMenu); } }  
        public string TextView { get; set; }
        public string AdmTextView { get; set; }
        public string TextViewCl { get { return SetClass(AdmTextView); } }                
        public string ViewTipo { get; set; }

        private string SetClass(string value)
        {
            return !string.IsNullOrEmpty(value) ? "enable" : "disable";
        }
    }
}