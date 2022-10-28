using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;

namespace Ishopping.Domain.Entities
{
    public class UserMenuViewItem
    {
        public Guid Id { get; private set; }
        public string TextMenu { get; private set; }           // texto do menu ex: equipe        
        public bool OnMenu { get; private set; }               // se o item sera exibido no menu
        public bool Activated { get; private set; }            // se o item deve aparecer na view 
        public string Link { get; private set; }               // local onde vai ser redirecionado ao se clicar no menu
        public string ItemTipo { get; private set; }

        // Relacionamento --------------------------
        public Guid UserMenuViewId { get; private set; }
        public virtual UserMenuView UserMenuView { get; private set; }

        // Ctor
        protected UserMenuViewItem() { }

        public UserMenuViewItem(UserMenuView userMenuView, string textMenu, bool onMenu, bool activated, string link, string itemTipo)
        {
            Validate(onMenu, textMenu, link, itemTipo);

            this.UserMenuView = userMenuView;
            this.TextMenu = textMenu;
            this.OnMenu = onMenu;
            this.Activated = activated;
            this.Link = link;
            this.ItemTipo = itemTipo;
        }

        // Methods
        public void Change(bool activated, string textMenu)
        {
            ValidateTextMenu(textMenu);
          
            this.TextMenu = textMenu;          
            this.Activated = activated;           
        }

        public void Change(UserMenuView userMenuView, string textMenu, bool onMenu, bool activated, string link, string itemTipo)
        {
            Validate(onMenu, textMenu, link, itemTipo);

            this.UserMenuView = userMenuView;
            this.TextMenu = textMenu;
            this.OnMenu = onMenu;
            this.Activated = activated;
            this.Link = link;
            this.ItemTipo = itemTipo;
        }

        private void ValidateTextMenu(string textMenu)
        {
            AssertionConcern.AssertArgumentNotNull(textMenu, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textMenu, 20, Errors.MaxLength);                   
        }

        private void Validate(bool onMenu, string textMenu, string link, string itemTipo)
        {
            if(onMenu)
            {
                ValidateTextMenu(textMenu);
                AssertionConcern.AssertArgumentNotNull(link, Errors.IsNull);
                AssertionConcern.AssertArgumentLength(link, 64, Errors.MaxLength);
            }     

            AssertionConcern.AssertArgumentNotNull(itemTipo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(itemTipo, 20, Errors.MaxLength);
        }
    }
}
