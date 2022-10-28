using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserAppearance 
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public string StyleName { get; private set; }
        public virtual ICollection<ConfigUserStyleColor> ConfigUserStyleColor { get; private set; }

        // Ctor
        protected ConfigUserAppearance() { }
      
        public ConfigUserAppearance(string userId, int siteNumber, ICollection<ConfigUserStyleColor> configUserStyleColor, string styleName)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(styleName);
                       
            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ConfigUserStyleColor = configUserStyleColor;
            this.StyleName = styleName;            
        }

        // Methods
        public void Change(ICollection<ConfigUserStyleColor> configUserStyleColor, string styleName)
        {
            Validate(styleName);

            this.ConfigUserStyleColor = configUserStyleColor;
            this.StyleName = styleName;  
        }

        private void Validate(string styleName)
        {      
            AssertionConcern.AssertArgumentLength(styleName, 20, Errors.MaxLength);
        }   
    }
}
