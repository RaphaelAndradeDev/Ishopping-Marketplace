using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentPricing : _Component
    {   
        public string NomePlano { get; private set; }     
        public bool Destacar { get; private set; }
        public string Moeda { get; private set; }
        public string PriceUnid { get; private set; }
        public string PriceCent { get; private set; }
        public string Periodo { get; private set; }
        public string Description { get; private set; }
        public string Comment { get; private set; }
        public string TextButton { get; private set; }
        public string UrlButton { get; private set; }
        public string Price { get { return PriceUnid + "," + PriceCent;} }

        // Get IsTags
        public string _NomePlano { get { return IsHtmlTags.GetTags(NomePlano); } }
        public string _Comment { get { return IsHtmlTags.GetTags(Comment); } }  
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        //Relacionamentos
        public Guid ComponentPricingOptionId { get; private set; }
        public virtual ComponentPricingOption ComponentPricingOption { get; private set; }

        // Ctor
        protected ComponentPricing() { }

        public ComponentPricing(string userId, int siteNumber, Guid componentPricingOptionId, 
            string nomePlano, string priceUnid, string priceCent, string periodo, string description = "", 
            string comment = "", string textButton = "", string urlButton = "", string moeda = "R$", bool destacar = false)
        {

            CommonValidate.Validate(userId, siteNumber);  
            Validate(nomePlano, priceUnid, priceCent, periodo, description, comment, textButton, urlButton, moeda);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentPricingOptionId = componentPricingOptionId;
            this.PriceUnid = priceUnid;
            this.PriceCent = priceCent;
            this.Periodo = periodo;
            this.TextButton = textButton;
            this.UrlButton = urlButton;
            this.Moeda = moeda;
            this.Destacar = destacar;
            this.LastChange = DateTime.Now;

            this.NomePlano = IsHtmlTags.SetTags(nomePlano);
            this.Search = IsHtmlTags.RemoveTags(nomePlano);
            this.Comment = IsHtmlTags.SetTags(comment);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentPricing(string userId, int siteNumber, ComponentPricingOption componentPricingOption,
            string nomePlano, string priceUnid, string priceCent, string periodo, string description = "",
            string comment = "", string textButton = "", string urlButton = "", string moeda = "R$", bool destacar = false)
        {

            CommonValidate.Validate(userId, siteNumber);
            Validate(nomePlano, priceUnid, priceCent, periodo, description, comment, textButton, urlButton, moeda);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentPricingOption = componentPricingOption;
            this.PriceUnid = priceUnid;
            this.PriceCent = priceCent;
            this.Periodo = periodo;
            this.TextButton = textButton;
            this.UrlButton = urlButton;
            this.Moeda = moeda;
            this.Destacar = destacar;
            this.LastChange = DateTime.Now;

            this.NomePlano = IsHtmlTags.SetTags(nomePlano);
            this.Search = IsHtmlTags.RemoveTags(nomePlano);
            this.Comment = IsHtmlTags.SetTags(comment);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentPricingOption(ComponentPricingOption componentPricingOption)
        {
            this.ComponentPricingOption = componentPricingOption;
        }

        public void ChangeComponentPricingOption(Guid componentPricingOptionId)
        {
            this.ComponentPricingOptionId = componentPricingOptionId;
        }

        public void Change(string nomePlano, string priceUnid, string priceCent, string periodo, string description = "", 
            string comment = "", string textButton = "", string urlButton = "", string moeda = "R$", bool destacar = false)
        {
            Validate(nomePlano, priceUnid, priceCent, periodo, description, comment, textButton, urlButton, moeda);
                        
            this.PriceUnid = priceUnid;
            this.PriceCent = priceCent;
            this.Periodo = periodo;
            this.TextButton = textButton;
            this.UrlButton = urlButton;
            this.Moeda = moeda;
            this.Destacar = destacar;

            this.NomePlano = IsHtmlTags.SetTags(nomePlano);
            this.Search = IsHtmlTags.RemoveTags(nomePlano);
            this.Comment = IsHtmlTags.SetTags(comment);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string nomePlano, string priceUnid, string priceCent, 
            string periodo, string description, string comment, string textButton, string urlButton, string moeda)
        {
            AssertionConcern.AssertArgumentNotEmpty(nomePlano, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(nomePlano, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(priceUnid, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(priceUnid, 6, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(priceCent, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(priceCent, 2, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(periodo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(periodo, 12, Errors.MaxLength);    

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(comment, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(textButton, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(urlButton, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(moeda, 3, Errors.MaxLength);
        }
    }
}
