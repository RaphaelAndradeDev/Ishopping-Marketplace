using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class UserMenuView
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
        public Guid UserMenuId { get; private set; }
        public virtual UserMenu UserMenu { get; private set; }
        public virtual ICollection<UserMenuViewItem> UserMenuViewItem { get; private set; }

        // Ctor
        protected UserMenuView() { }

        public UserMenuView(UserMenu userMenu, string textMenu, string view, string controller,
           string viewName, int viewCod, string viewTipo, bool onMenu, string viewLink, bool activated, string active = "")
        {
            Validate(textMenu, view, controller, viewName, viewCod, viewTipo, viewLink, active);

            this.UserMenu = userMenu;        
            this.TextMenu = textMenu;
            this.View = view;
            this.Controller = controller;
            this.ViewName = viewName;
            this.ViewCod = viewCod;
            this.ViewTipo = viewTipo;
            this.OnMenu = onMenu;
            this.ViewLink = viewLink;
            this.Activated = activated;
            this.Active = active;
        }

        // Methods
        public void Change(string textMenu, bool activated)
        {
            Validate(textMenu);
     
            this.TextMenu = textMenu;     
            this.Activated = activated;        
        }

        public void Change(UserMenu userMenu, string textMenu, string view, string controller,
           string viewName, int viewCod, string viewTipo, bool onMenu, string viewLink, bool activated, string active = "")
        {
            Validate(textMenu, view, controller, viewName, viewCod, viewTipo, viewLink, active);

            this.UserMenu = userMenu;          
            this.TextMenu = textMenu;
            this.View = view;
            this.Controller = controller;
            this.ViewName = viewName;
            this.ViewCod = viewCod;
            this.ViewTipo = viewTipo;
            this.OnMenu = onMenu;
            this.ViewLink = viewLink;
            this.Activated = activated;
            this.Active = active;
        }

        public void AddListUserMenuViewItem(ICollection<UserMenuViewItem> userMenuViewItem)
        {
              this.UserMenuViewItem = userMenuViewItem;
        }

        private void Validate(string textMenu, string view, string controller, string viewName, int viewCod,
            string viewTipo, string viewLink, string active)
        {

            Validate(textMenu);
          
            AssertionConcern.AssertArgumentNotNull(view, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(view, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(controller, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(controller, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(viewName, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(viewName, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(viewCod, 1111, 9999, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentNotNull(viewTipo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(viewTipo, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(viewLink, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(viewLink, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(active, 20, Errors.MaxLength);
        }

        private void Validate(string textMenu)
        {
            AssertionConcern.AssertArgumentNotNull(textMenu, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textMenu, 20, Errors.MaxLength);
        }
    }
}
