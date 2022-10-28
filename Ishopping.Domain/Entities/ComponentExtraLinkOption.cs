using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentExtraLinkOption : _Option
    {  
        public string Description { get; private set; }
        public string TextLink { get; private set; }

        // Relacionamentos   
        public virtual ICollection<ComponentExtraLink> ComponentExtraLink { get; private set; }

        // Ctor
        protected ComponentExtraLinkOption() { }
    
        public ComponentExtraLinkOption(string userId, bool isDefault, string textLink, string description)
        {
            CommonValidate.Validate(userId);
            Validate(textLink, description);

            this.IdUser = userId;
            this.Default = isDefault;
            this.TextLink = textLink;
            this.Description = description;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string textLink, string description)
        {
            Validate(textLink, description);

            this.Default = isDefault;
            this.TextLink = textLink;
            this.Description = description;
        }

        private void Validate(string textLink, string description)
        {         
            AssertionConcern.AssertArgumentNotEmpty(textLink, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textLink, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);
        }
    }
}
