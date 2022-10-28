using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentService : _Component
    {    
        public int Position { get; private set; }
        public string Title { get; private set; }    
        public string Description { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        // Relacionamentos       
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public Guid ComponentServiceOptionId { get; private set; }
        public virtual ComponentServiceOption ComponentServiceOption { get; private set; }

        // Ctor
        protected ComponentService() { }

        public ComponentService(string userId, int siteNumber, Guid userImageGalleryId, Guid componentServiceOptionId, 
            string title, string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber); 
            Validate(title, description, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentServiceOptionId = componentServiceOptionId;            
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentService(string userId, int siteNumber, Guid userImageGalleryId, ComponentServiceOption componentServiceOption,
            string title, string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, description, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentServiceOption = componentServiceOption;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentServiceOption(ComponentServiceOption componentServiceOption)
        {
            this.ComponentServiceOption = componentServiceOption;
        }

        public void ChangeComponentServiceOption(Guid componentServiceOptionId)
        {
            this.ComponentServiceOptionId = componentServiceOptionId;
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, string title, string description = "", int position = 1)
        {
            this.UserImageGalleryId = userImageGalleryId;         
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string title, string description, int position)
        {             
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);
        }
    }
}
