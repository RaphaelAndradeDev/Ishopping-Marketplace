using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentMenuOption : _Option
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Price { get; private set; }   

        //Relacionamentos
        public virtual ICollection<ComponentMenu> ComponentMenu { get; private set; }

        // Ctor
        protected ComponentMenuOption() { }

        public ComponentMenuOption(string userId, bool isDefault, string title, string description, string price)
        {
            CommonValidate.Validate(userId);  
            Validate(title, description, price);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string title, string description, string price)
        {
            Validate(title, description, price);

            this.Default = isDefault;
            this.Title = title;
            this.Description = description;
            this.Price = price;
        }
        private void Validate(string title, string description, string price)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(price, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(price, 64, Errors.MaxLength);
        }
    }
}
