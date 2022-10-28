using System;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserMenuViewItemViewModel
    {
        public Guid Id { get; private set; }
        public string TextMenu { get; private set; }           // texto do menu ex: equipe        
        public bool OnMenu { get; private set; }               // se o item sera exibido no menu
        public bool Activated { get; private set; }            // se o item deve aparecer na view 
        public string Link { get; private set; }               // local onde vai ser redirecionado ao se clicar no menu
        public string ItemTipo { get; private set; }      
    }
}
