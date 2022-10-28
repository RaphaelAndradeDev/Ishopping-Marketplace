using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ContentVideo : _Content
    {       
        public string Url { get; private set; }    

        // Ctor
        protected ContentVideo() { }
  
        public ContentVideo(string userId, int siteNumber, int viewCod, int position, string url)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, url);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ViewCod = viewCod;
            this.Position = position;
            this.Url = url;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(int viewCod, int position, string url)
        {
            Validate(viewCod, position, url);

            this.ViewCod = viewCod;
            this.Position = position;
            this.Url = url;
        }

        private void Validate(int viewCod, int position, string url)
        {         
            AssertionConcern.AssertArgumentRange(viewCod, 1111, 9999, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 99, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(url, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(url, 256, Errors.MaxLength);          
        }
    }
}
