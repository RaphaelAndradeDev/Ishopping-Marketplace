using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentExtraLink :_Component
    {    
        public string TextLink { get; private set; }  
        public string Link { get; private set; }
        public string Description { get; private set; }

        // Get IsTags
        public string _TextLink { get { return IsHtmlTags.GetTags(TextLink); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        // Relacionamentos   
        public Guid ComponentExtraLinkOptionId { get; private set; }
        public virtual ComponentExtraLinkOption ComponentExtraLinkOption { get; private set; }

        // Ctor
        protected ComponentExtraLink() { }

        public ComponentExtraLink(string userId, int siteNumber, Guid componentExtraLinkOptionId, string textLink, string link, string description = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(textLink, link, description);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentExtraLinkOptionId = componentExtraLinkOptionId;
            this.Link = link;
            this.LastChange = DateTime.Now;

            this.TextLink = IsHtmlTags.SetTags(textLink);
            this.Search = IsHtmlTags.RemoveTags(textLink);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentExtraLink(string userId, int siteNumber, ComponentExtraLinkOption componentExtraLinkOption, string textLink, string link, string description = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(textLink, link, description);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentExtraLinkOption = componentExtraLinkOption;
            this.Link = link;
            this.LastChange = DateTime.Now;

            this.TextLink = IsHtmlTags.SetTags(textLink);
            this.Search = IsHtmlTags.RemoveTags(textLink);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentExtraLinkOption(ComponentExtraLinkOption componentExtraLinkOption)
        {
            this.ComponentExtraLinkOption = componentExtraLinkOption;
        }

        public void ChangeComponentExtraLinkOption(Guid componentExtraLinkOptionId)
        {
            this.ComponentExtraLinkOptionId = ComponentExtraLinkOptionId;
        }

        public void Change(string textLink, string link, string description = "")
        {
            Validate(textLink, link, description);
            
            this.Link = link;

            this.TextLink = IsHtmlTags.SetTags(textLink);
            this.Search = IsHtmlTags.RemoveTags(textLink);
            this.Description = IsHtmlTags.SetTags(description);
        }
        private void Validate(string textLink, string link, string description)
        {          
            AssertionConcern.AssertArgumentNotEmpty(textLink, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textLink, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(link, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(link, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);
        }
    }
}
