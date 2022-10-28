﻿using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentSummaryOption : _Option
    {        
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }

        //Relacionamentos
        public virtual ICollection<ComponentSummary> ComponentSummary { get; private set; }

        // Ctor
        protected ComponentSummaryOption() { }

        public ComponentSummaryOption(string userId, bool isDefault, string title, string catetory, string description)
        {
            CommonValidate.Validate(userId); 
            Validate(title, catetory, description);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Title = title;
            this.Category = catetory;
            this.Description = description;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string title, string catetory, string description)
        {
            Validate(title, catetory, description);

            this.Default = isDefault;
            this.Title = title;
            this.Category = catetory;
            this.Description = description;
        }

        private void Validate(string title, string category, string description)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);
        }
    }
}
