using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentFeaturesOption : _Option
    {
        public string Title { get; private set; }
        public string Count { get; private set; }
        public string Description { get; private set; }

        //Relacionamento
        public virtual ICollection<ComponentFeatures> ComponentFeatures { get; private set; }

        //Ctor
        protected ComponentFeaturesOption() { }
    
        public ComponentFeaturesOption(string userId, bool isDefault, string title, string count, string description)
        {
            CommonValidate.Validate(userId); 
            Validate(title, count, description);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Title = title;
            this.Count = count;
            this.Description = description;
            this.LastChange = DateTime.Now;
        }

        //Methods
        public void Change(bool isDefault, string title, string count, string description)
        {
            Validate(title, count, description);

            this.Default = isDefault;
            this.Title = title;
            this.Count = count;
            this.Description = description;
        }

        private void Validate(string title, string count, string description)
        {             
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(count, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(count, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);
        }
    }
}
