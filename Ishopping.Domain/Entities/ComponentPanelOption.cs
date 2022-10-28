using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentPanelOption : _Option
    {    
        public string Title { get; private set; }
        public string Text { get; private set; }

        // Relacionamentos
        public virtual ICollection<ComponentPanel> ComponentPanel { get; private set; }

        // Ctor
        protected ComponentPanelOption() { }

        public ComponentPanelOption(string userId, bool isDefault, string title, string text)
        {
            CommonValidate.Validate(userId);  
            Validate(title, text);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Title = title;
            this.Text = text;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string title, string text)
        {
            Validate(title, text);

            this.Default = isDefault;
            this.Title = title;
            this.Text = text;
        }

        private void Validate(string title, string text)
        {           
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(text, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(text, 64, Errors.MaxLength);
        }
    }
}
