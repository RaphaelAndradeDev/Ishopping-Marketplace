using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentPortofolioOption : _Option
    { 
        public string Category { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string List { get; private set; }   
 
        //Relacionamentos
        public virtual ICollection<ComponentPortofolio> ComponentPortofolio { get; private set; }

        // Ctor
        protected ComponentPortofolioOption() { }

        public ComponentPortofolioOption(string userId, bool isDefault, string category, string title, string description, string list)
        {
            CommonValidate.Validate(userId);  
            Validate(category, title, description, list);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Category = category;
            this.Title = title;
            this.Description = description;
            this.List = list;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string category, string title, string description, string list)
        {
            Validate(category, title, description, list);

            this.Default = isDefault;
            this.Category = category;
            this.Title = title;
            this.Description = description;
            this.List = list;
        }

        private void Validate(string category, string title, string description, string list)
        {           
            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(list, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(list, 64, Errors.MaxLength);
        }
    }
}
