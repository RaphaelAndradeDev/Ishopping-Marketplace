using System.Collections.Generic;

namespace Ishopping.Mvc.Serialization.User
{
    public class UserMenuViewSerialization
    {      
        public string TextMenu { get; set; }      
        public bool OnMenu { get; set; }                // se o item sera exibido no menu
        public string ViewLink { get; set; }            // Link onde sera redirecionado o item na view ao clicar
        public bool Activated { get; set; }            // se o item deve aparecer na view    
        public string Active { get; set; }              // se o item do menu deve aparecer destacado na view 


        // Relacionamento ------------------------------ 
        public virtual ICollection<UserMenuViewItemSerialization> UserMenuViewItem { get; set; }               
    }
}
