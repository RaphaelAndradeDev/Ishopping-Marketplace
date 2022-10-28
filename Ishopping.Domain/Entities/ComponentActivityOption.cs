using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentActivityOption : _Option
    {       
        public string Title { get; private set; }          
        public string Description { get; private set; }    

        // Relacionamentos
        public virtual ICollection<ComponentActivity> ComponentActivity { get; private set; }

        // Ctor
        protected ComponentActivityOption() { }
       
        public ComponentActivityOption(string userId, bool isDefault, string title, string description)
        {
            CommonValidate.Validate(userId); 
            Validate(title, description);
              
            this.IdUser = userId;
            this.Default = isDefault;
            this.Title = title;
            this.Description = description;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string title, string description)
        {
            Validate(title, description);

            this.Default = isDefault;
            this.Title = title;
            this.Description = description;
        }
        
        private void Validate(string title, string description)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);
        }
    }
}
