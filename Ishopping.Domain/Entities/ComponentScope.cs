using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentScope : _Component
    {        
        public int Position { get; private set; }
        public string Title { get; private set; }     
        public string Category { get; private set; }
        public string VectorIcon { get; private set; }
        public string Description { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        //Relacionamentos
        public Guid ComponentScopeOptionId { get; private set; }
        public virtual ComponentScopeOption ComponentScopeOption { get; private set; }

        // Ctor
        protected ComponentScope() { }

        public ComponentScope(string userId, int siteNumber, Guid ComponentScopeOptionId, 
            string title, string icon, string category = "", string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, icon, category, description, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentScopeOptionId = ComponentScopeOptionId;
            this.VectorIcon = icon;
            this.Category = category;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentScope(string userId, int siteNumber, ComponentScopeOption ComponentScopeOption,
            string title, string icon, string category = "", string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, icon, category, description, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentScopeOption = ComponentScopeOption;
            this.VectorIcon = icon;
            this.Category = category;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentScopeOption(ComponentScopeOption componentScopeOption)
        {
            this.ComponentScopeOption = componentScopeOption;
        }

        public void ChangeComponentScopeOption(Guid componentScopeOptionId)
        {
            this.ComponentScopeOptionId = componentScopeOptionId;
        }

        public void Change(string title, string icon, string category = "", string description = "", int position = 1)
        {
            Validate(title, icon, category, description, position);
                   
            this.VectorIcon = icon;
            this.Category = category;
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string title, string icon, string category, string description, int position)
        {           
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(icon, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);
        }
    }
}
