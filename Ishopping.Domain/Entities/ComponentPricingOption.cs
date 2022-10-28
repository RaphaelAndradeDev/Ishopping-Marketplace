using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentPricingOption : _Option
    {     
        public string NomePlano { get; private set; }
        public string Moeda { get; private set; }
        public string PriceUnid { get; private set; }
        public string PriceCent { get; private set; }
        public string Periodo { get; private set; }
        public string Description { get; private set; }
        public string Comment { get; private set; }
        public string TextButton { get; private set; }
        public string Price { get; private set; }

        //Relacionamentos
        public virtual ICollection<ComponentPricing> ComponentPricing { get; private set; }

        // Ctor
        protected ComponentPricingOption() { }

        public ComponentPricingOption(string userId, bool isDefault, string nomePlano, string moeda, string priceUnid, 
            string priceCent, string periodo, string description, string comment, string textButton, string price)
        {
            CommonValidate.Validate(userId);  
            Validate(nomePlano, moeda, priceUnid, priceCent, periodo, description, comment, textButton, price);

            this.IdUser = userId;
            this.Default = isDefault;
            this.NomePlano = nomePlano;
            this.Moeda = moeda;
            this.PriceUnid = priceUnid;
            this.PriceCent = priceCent;
            this.Periodo = periodo;
            this.Description = description;
            this.Comment = comment;
            this.TextButton = textButton;
            this.Price = price;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string nomePlano, string moeda, string priceUnid,
            string priceCent, string periodo, string description, string comment, string textButton, string price)
        {
            Validate(nomePlano, moeda, priceUnid, PriceCent, periodo, description, comment, textButton, price);

            this.Default = isDefault;
            this.NomePlano = nomePlano;
            this.Moeda = moeda;
            this.PriceUnid = priceUnid;
            this.PriceCent = priceCent;
            this.Periodo = periodo;
            this.Description = description;
            this.Comment = comment;
            this.TextButton = textButton;
            this.Price = price;
        }

        private void Validate(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price)
        {         
            AssertionConcern.AssertArgumentNotEmpty(nomePlano, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(nomePlano, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(moeda, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(moeda, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(priceUnid, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(priceUnid, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(priceCent, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(priceCent, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(periodo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(periodo, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(comment, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(comment, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(textButton, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textButton, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(price, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(price, 64, Errors.MaxLength);
        }
    }
}
