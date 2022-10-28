using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserMenuView_ViewModel
    {
        public Guid Id { get; private set; }
        public string TextMenu { get; private set; }
        public string View { get; private set; }
        public string Controller { get; private set; }
        public string ViewName { get; private set; }
        public int ViewCod { get; private set; }               // Código único da view
        public string ViewTipo { get; private set; }
        public bool OnMenu { get; private set; }                // se o item sera exibido no menu
        public string ViewLink { get; private set; }            // Link onde sera redirecionado o item na view ao clicar
        public bool Activated { get; private set; }            // se o item deve aparecer na view    
        public string Active { get; private set; }              // se o item do menu deve aparecer destacado na view 

        // Relacionamento ------------------------------   
        public virtual ICollection<UserMenuViewItemViewModel> UserMenuViewItem { get; private set; }
    }
}
