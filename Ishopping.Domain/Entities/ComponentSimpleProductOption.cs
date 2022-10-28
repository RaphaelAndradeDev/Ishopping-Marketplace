using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentSimpleProductOption : _Option
    {       
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string Price { get; private set; }       

        //Relacionamentos
        public virtual ICollection<ComponentSimpleProduct> ComponentSimpleProduct { get; private set; }

        // Ctor
        protected ComponentSimpleProductOption() { }

        public ComponentSimpleProductOption(string userId, bool isDefault, string name, string category, string brand, string model, string description, string price)
        {
            CommonValidate.Validate(userId);  
            Validate(name, category, brand, model, description, price);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Name = name;
            this.Category = category;
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.Price = price;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string name, string category, string brand, string model, string description, string price)
        {
            Validate(name, category, brand, model, description, price);

            this.Default = isDefault;
            this.Name = name;
            this.Category = category;
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.Price = price;
        }

        private void Validate(string name, string category, string brand, string model, string description, string price)
        {    
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(brand, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(brand, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(model, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(model, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(price, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(price, 64, Errors.MaxLength);
        }
    }
}
