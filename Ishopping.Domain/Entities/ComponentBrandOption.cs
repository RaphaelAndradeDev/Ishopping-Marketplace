using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentBrandOption : _Option
    {       
        public string Marca { get; private set; }
        public string Comment { get; private set; }

        // Relacionamentos  
        public virtual ICollection<ComponentBrand> ComponentBrand { get; private set; }

        // Ctor
        protected ComponentBrandOption() { }
       
        public ComponentBrandOption(string userId, bool isDefault, string marca, string comment)
        {
            CommonValidate.Validate(userId);
            Validate(marca, comment);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Marca = marca;
            this.Comment = comment;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string marca, string comment)
        {
            Validate(marca, comment);

            this.Default = isDefault;
            this.Marca = marca;
            this.Comment = comment;
        }

        private void Validate(string marca, string comment)
        {         
            AssertionConcern.AssertArgumentNotEmpty(marca, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(marca, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(comment, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(comment, 64, Errors.MaxLength);
        }
    }
}
