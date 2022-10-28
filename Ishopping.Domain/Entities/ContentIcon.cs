using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ContentIcon : _Content
    {        
        public string Icon { get; private set; }
     

        //Ctor
        protected ContentIcon() { }
    
        public ContentIcon(string userId, int siteNumber, int viewCod, int position, string icon)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, icon);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ViewCod = viewCod;
            this.Position = position;
            this.Icon = icon;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(int viewCod, int position, string icon)
        {
            Validate(viewCod, position, icon);

            this.ViewCod = viewCod;
            this.Position = position;
            this.Icon = icon;
        }

        private void Validate(int viewCod, int position, string icon)
        {            
            AssertionConcern.AssertArgumentRange(viewCod, 1111, 9999, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 99, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(icon, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);          
        }
    }
}
