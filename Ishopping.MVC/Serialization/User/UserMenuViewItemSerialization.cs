
namespace Ishopping.Mvc.Serialization.User
{
    public class UserMenuViewItemSerialization
    {  
        public string TextMenu { get; set; }           // texto do menu ex: equipe        
        public bool OnMenu { get; set; }               // se o item sera exibido no menu
        public bool Activated { get; set; }            // se o item deve aparecer na view 
        public string Link { get; set; }               // local onde vai ser redirecionado ao se clicar no menu
        public string ItemTipo { get; set; }         
    }
}
