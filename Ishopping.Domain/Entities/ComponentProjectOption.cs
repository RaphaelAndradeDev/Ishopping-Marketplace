using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentProjectOption : _Option
    {          
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Client { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Team { get; private set; }  

        //Relacionamentos
        public virtual ICollection<ComponentProject> ComponentProject { get; private set; }

        // Ctor
        protected ComponentProjectOption() { }

        public ComponentProjectOption(string userId, bool isDefault, string name, string title, string client, string description, string category, string team)
        {
            CommonValidate.Validate(userId);  
            Validate(name, title, client, description, category, team);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Name = name;
            this.Title = title;
            this.Client = client;
            this.Description = description;
            this.Category = category;
            this.Team = team;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string name, string title, string client, string description, string category, string team)
        {
            Validate(name, title, client, description, category, team);

            this.Default = isDefault;
            this.Name = name;
            this.Title = title;
            this.Client = client;
            this.Description = description;
            this.Category = category;
            this.Team = team; 
        }

        private void Validate(string name, string title, string client, string description, string category, string team)
        {         
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(client, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(client, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(team, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(team, 64, Errors.MaxLength);   
        }
    }
}
