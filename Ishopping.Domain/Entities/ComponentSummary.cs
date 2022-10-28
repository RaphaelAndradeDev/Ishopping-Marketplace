using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentSummary : _Component
    {       
        public int Position { get; private set; }
        public string Title { get; private set; }  
        public string Category { get; private set; }
        public string Description { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        //Relacionamentos
        public Guid ComponentSummaryOptionId { get; private set; }
        public virtual ComponentSummaryOption ComponentSummaryOption { get; private set; }

        // Ctor
        protected ComponentSummary() { }
      
        public ComponentSummary(string userId, int siteNumber, Guid componentSummaryOptionId, string title, string description, string category = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber); 
            Validate(title, description, category, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentSummaryOptionId = componentSummaryOptionId;
            this.Category = category;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentSummary(string userId, int siteNumber, ComponentSummaryOption componentSummaryOption, string title, string description, string category = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, description, category, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentSummaryOption = componentSummaryOption;
            this.Category = category;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentSummaryOption(ComponentSummaryOption componentSummaryOption)
        {
            this.ComponentSummaryOption = componentSummaryOption;
        }

        public void ChangeComponentSummaryOption(Guid componentSummaryOptionId)
        {
            this.ComponentSummaryOptionId = componentSummaryOptionId;
        }

        public void Change(string title, string description, string category = "", int position = 1)
        {
            Validate(title, description, category, position);
                    
            this.Category = category;
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string title, string description, string category, int position)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);
        }
    }
}
