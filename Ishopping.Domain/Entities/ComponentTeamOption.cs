using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentTeamOption : _Option
    {     
        public string Name { get; private set; }
        public string Functio { get; private set; }
        public string Description { get; private set; }  
 
        //Relacionamentos
        public virtual ICollection<ComponentTeam> ComponentTeam { get; private set; }

        // Ctor
        protected ComponentTeamOption() { }

        public ComponentTeamOption(string userId, bool isDefault, string name, string functio, string description)
        {
            CommonValidate.Validate(userId); 
            Validate(name, functio, description);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Name = name;
            this.Functio = functio;
            this.Description = description;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string name, string functio, string description)
        {
            Validate(name, functio, description);

            this.Default = isDefault;
            this.Name = name;
            this.Functio = functio;
            this.Description = description;
        }

        private void Validate(string title, string functio, string description)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(functio, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(functio, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);
        }
    }
}
