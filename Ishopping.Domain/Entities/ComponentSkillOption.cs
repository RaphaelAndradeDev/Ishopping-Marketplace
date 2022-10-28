using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentSkillOption : _Option
    {       
        public string Category { get; private set; }
        public string Description { get; private set; }
        public string Level { get; private set; }   

        //Relacionamentos
        public virtual ICollection<ComponentSkill> ComponentSkill { get; private set; }

        // Ctor
        protected ComponentSkillOption() { }

        public ComponentSkillOption(string userId, bool isDefault, string category, string description, string level)
        {
            CommonValidate.Validate(userId);  
            Validate(category, description, level);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Category = category;
            this.Description = description;
            this.Level = level;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string category, string description, string level)
        {
            Validate(category, description, level);

            this.Default = isDefault;
            this.Category = category;
            this.Description = description;
            this.Level = level;
        }

        private void Validate(string category, string description, string level)
        {            
            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(level, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(level, 64, Errors.MaxLength);
        }
    }
}
