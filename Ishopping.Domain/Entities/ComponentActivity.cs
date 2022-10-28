using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentActivity : _Component
    {        
        public int Position { get; private set; }
        public string Title { get; private set; }      
        public string VectorIcon { get; private set; }
        public string Description { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        // Relacionamento
        public Guid ComponentActivityOptionId { get; private set; }
        public virtual ComponentActivityOption ComponentActivityOption { get; private set; }

        // Ctor
        protected ComponentActivity() { }

        public ComponentActivity(string userId, int siteNumber, ComponentActivityOption componentActivityOption, string title, string icon, string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, description, icon, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentActivityOption = componentActivityOption;
            this.VectorIcon = icon;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentActivity(string userId, int siteNumber, Guid componentActivityOptionId, string title, string icon, string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber); 
            Validate(title, description, icon, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentActivityOptionId = componentActivityOptionId;
            this.VectorIcon = icon;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentActivityOption(ComponentActivityOption componentActivityOption)
        {
            this.ComponentActivityOption = componentActivityOption;
        } 

        public void ChangeComponentActivityOption(Guid componentActivityOptionId)
        {
            this.ComponentActivityOptionId = componentActivityOptionId;
        }                    

        public void Change(string title, string icon, string description = "", int position = 1)
        {
            Validate(title, description, icon, position);
                     
            this.VectorIcon = icon;
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);            
        }

        private void Validate(string title, string description, string icon, int position)
        {                      
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(icon, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);
        }
    }
}
