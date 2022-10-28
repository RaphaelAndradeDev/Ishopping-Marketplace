using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentClientOption : _Option
    {      
        public string Name { get; private set; }
        public string Functio { get; private set; }
        public string Comment { get; private set; }
        public string Projects { get; private set; }

        // Relacionamentos 
        public virtual ICollection<ComponentClient> ComponentClient { get; private set; }

        // Ctor
        protected ComponentClientOption() { }
   
        public ComponentClientOption(string userId, bool isDefault, string name, string functio, string comment, string projects)
        {
            CommonValidate.Validate(userId);
            Validate(name, functio, comment, projects);
   
            this.IdUser = userId;
            this.Default = isDefault;
            this.Name = name;
            this.Functio = functio;
            this.Comment = comment;
            this.Projects = projects;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string name, string functio, string comment, string projects)
        {
            Validate(name, functio, comment, projects);

            this.Default = isDefault;
            this.Name = name;
            this.Functio = functio;
            this.Comment = comment;
            this.Projects = projects;
        }

        private void Validate(string name, string functio, string comment, string projects)
        {           
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(functio, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(functio, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(comment, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(comment, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(projects, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(projects, 64, Errors.MaxLength);
        }
    }
}
