using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentFeatures : _Component
    { 
        public string Title { get; private set; }      
        public string Icon { get; private set; }
        public int Count { get; private set; }
        public string Description { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        //Relacionamentos
        public Guid ComponentFeaturesOptionId { get; private set; }
        public virtual ComponentFeaturesOption ComponentFeaturesOption { get; private set; }

        // Ctor
        protected ComponentFeatures() { }

        public ComponentFeatures(string userId, int siteNumber, Guid componentFeaturesOptionId, string title, int count, string icon = "", string description = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, count, icon, description);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentFeaturesOptionId = componentFeaturesOptionId;
            this.Count = count;
            this.Icon = icon;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentFeatures(string userId, int siteNumber, ComponentFeaturesOption componentFeaturesOption, string title, int count, string icon = "", string description = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, count, icon, description);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentFeaturesOption = componentFeaturesOption;
            this.Count = count;
            this.Icon = icon;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentFeaturesOption(ComponentFeaturesOption componentFeaturesOption)
        {
            this.ComponentFeaturesOption = componentFeaturesOption;
        }

        public void ChangeComponentFeaturesOption(Guid componentFeaturesOptionId)
        {
            this.ComponentFeaturesOptionId = componentFeaturesOptionId;
        }

        public void Change(string title, int count, string icon = "", string description = "")
        {
            Validate(title, count, icon, description);
                 
            this.Count = count;
            this.Icon = icon;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string title, int count, string icon, string description)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(count, 0, int.MaxValue, Errors.IsNull);

            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);
        }
    }
}
