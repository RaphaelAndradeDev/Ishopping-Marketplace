using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ContentText : _Content
    {      
        public string Text32 { get; private set; }
        public string Search32 { get; private set; }
        public string Text512 { get; private set; }
        public string Search512 { get; private set; }
        public string Text5120 { get; private set; }
        public string Search5120 { get; private set; }
       

        // Get IsTags
        public string _Text32 { get { return IsHtmlTags.GetTags(Text32); } }
        public string _Text512 { get { return IsHtmlTags.GetTags(Text512); } }
        public string _Text5120 { get { return IsHtmlTags.GetTags(Text5120); } }


        //Relacionamentos
        public Guid ContentTextOptionId { get; private set; }
        public virtual ContentTextOption ContentTextOption { get; private set; }

        // Ctor
        protected ContentText() { }

        public ContentText(string userId, int siteNumber, Guid contentTextOptionId, int viewCod, int position,
            string text32 = "", string text512 = "", string text5120 = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, text32, text512, text5120);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ContentTextOptionId = contentTextOptionId;
            this.ViewCod = viewCod;
            this.Position = position;
            this.Text32 = IsHtmlTags.SetTags(text32);
            this.Search32 = IsHtmlTags.RemoveTags(text32);
            this.Text512 = IsHtmlTags.SetTags(text512);
            this.Search512 = IsHtmlTags.RemoveTags(text512);
            this.Text5120 = IsHtmlTags.SetTags(text5120);
            this.Search5120 = IsHtmlTags.RemoveTags(text5120);
            this.LastChange = DateTime.Now;
        }

        public ContentText(string userId, int siteNumber, ContentTextOption contentTextOption, int viewCod, int position,
            string text32 = "", string text512 = "", string text5120 = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, text32, text512, text5120);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ContentTextOption = contentTextOption;
            this.ViewCod = viewCod;
            this.Position = position;
            this.Text32 = IsHtmlTags.SetTags(text32);
            this.Search32 = IsHtmlTags.RemoveTags(text32);
            this.Text512 = IsHtmlTags.SetTags(text512);
            this.Search512 = IsHtmlTags.RemoveTags(text512);
            this.Text5120 = IsHtmlTags.SetTags(text5120);
            this.Search5120 = IsHtmlTags.RemoveTags(text5120);
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void AddContentTextOption(ContentTextOption contentTextOption)
        {
            this.ContentTextOption = contentTextOption;
        }

        public void ChangeContentTextOption(Guid contentTextOptionId)
        {
            this.ContentTextOptionId = contentTextOptionId;
        }

        public void Change(int viewCod, int position, string text32 = "", string text512 = "", string text5120 = "")
        {
            Validate(viewCod, position, text32, text512, text5120);
                        
            this.ViewCod = viewCod;
            this.Position = position;
            this.Text32 = IsHtmlTags.SetTags(text32);
            this.Search32 = IsHtmlTags.RemoveTags(text32);
            this.Text512 = IsHtmlTags.SetTags(text512);
            this.Search512 = IsHtmlTags.RemoveTags(text512);
            this.Text5120 = IsHtmlTags.SetTags(text5120);
            this.Search5120 = IsHtmlTags.RemoveTags(text5120);
        }

        private void Validate(int viewCod, int position, string Text32, string Text512, string Text5120)
        {
            AssertionConcern.AssertArgumentRange(viewCod, 1111, 9999, Errors.MaxLength);
            AssertionConcern.AssertArgumentRange(position, 1, 99, Errors.MaxLength);                 
            AssertionConcern.AssertArgumentLength(Text32, 64, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(Text512, 512, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(Text5120, 5120, Errors.MaxLength); 
        }
    }
}
