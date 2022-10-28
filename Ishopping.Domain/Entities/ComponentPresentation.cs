using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentPresentation : _Component
    {       
        public int Position { get; private set; }
        public string Title { get; private set; }   
        public string Category { get; private set; }
        public string Description { get; private set; }
        public string VectorIcon { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        // Relacionamentos       
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public Guid ComponentPresentationOptionId { get; private set; }
        public virtual ComponentPresentationOption ComponentPresentationOption { get; private set; }

        // Ctor
        protected ComponentPresentation() { }

        public ComponentPresentation(string userId, int siteNumber, Guid userImageGalleryId, Guid componentPresentationOptionId,
            string title, string category, string description, string icon = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber); 
            Validate(title, category, description, icon, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentPresentationOptionId = componentPresentationOptionId;
            this.Category = category;
            this.VectorIcon = icon;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentPresentation(string userId, int siteNumber, Guid userImageGalleryId, ComponentPresentationOption componentPresentationOption,
            string title, string category, string description, string icon = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, category, description, icon, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentPresentationOption = componentPresentationOption;
            this.Category = category;
            this.VectorIcon = icon;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentPresentationOption(ComponentPresentationOption componentPresentationOption)
        {
            this.ComponentPresentationOption = componentPresentationOption;
        }

        public void ChangeComponentPresentationOption(Guid componentPresentationOptionId)
        {
            this.ComponentPresentationOptionId = componentPresentationOptionId;
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, string title, string category, string description, string icon = "", int position = 1)
        {
            Validate(title, category, description, icon, position);

            this.UserImageGalleryId = userImageGalleryId;       
            this.Category = category;
            this.VectorIcon = icon;
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string title, string category, string description, string icon, int position)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);        

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);
        }
    }
}
