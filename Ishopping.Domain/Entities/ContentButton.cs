using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ContentButton : _Content
    {
        public string Search { get; private set; }
        public string TextBtn { get; private set; }      
        public string TextURL { get; private set; }

        // Get IsTags
        public string _TextBtn { get { return IsHtmlTags.GetTags(TextBtn); } }

        //Relacionamentos
        public Guid ContentButtonOptionId { get; private set; }
        public virtual ContentButtonOption ContentButtonOption { get; private set; }

        //Ctor
        protected ContentButton() { }
   
        public ContentButton(string userId, int siteNumber, Guid contentButtonOptionId, int viewCod, int position, string textButton, string textUrl = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, textButton, textUrl);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ContentButtonOptionId = contentButtonOptionId;
            this.ViewCod = viewCod;
            this.Position = position;
            this.TextBtn = IsHtmlTags.SetTags(textButton);
            this.Search = IsHtmlTags.RemoveTags(textButton);
            this.TextURL = textUrl;
            this.LastChange = DateTime.Now;
        }

        public ContentButton(string userId, int siteNumber, ContentButtonOption contentButtonOption, int viewCod, int position, string textButton, string textUrl = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, textButton, textUrl);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ContentButtonOption = contentButtonOption;
            this.ViewCod = viewCod;
            this.Position = position;
            this.TextBtn = IsHtmlTags.SetTags(textButton);
            this.Search = IsHtmlTags.RemoveTags(textButton);
            this.TextURL = textUrl;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void AddContentButtonOption(ContentButtonOption contentButtonOption)
        {
            this.ContentButtonOption = contentButtonOption;
        }

        public void ChangeContentButtonOption(Guid contentButtonOptionId)
        {
            this.ContentButtonOptionId = contentButtonOptionId;
        }

        public void Change(int viewCod, int position, string textButton, string textUrl = "")
        {
            Validate(viewCod, position, textButton, textUrl);
                       
            this.ViewCod = viewCod;
            this.Position = position;
            this.TextBtn = IsHtmlTags.SetTags(textButton);
            this.Search = IsHtmlTags.RemoveTags(textButton);
            this.TextURL = textUrl;
        }

        private void Validate(int viewCod, int position, string textButton, string textUrl)
        {           
            AssertionConcern.AssertArgumentRange(viewCod, 1111, 9999, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 99, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(textButton, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textButton, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(textUrl, 128, Errors.MaxLength);            
        }
    }
}
