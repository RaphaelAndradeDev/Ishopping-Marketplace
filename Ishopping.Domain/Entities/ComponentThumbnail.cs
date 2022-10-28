using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentThumbnail : _Component
    {      
        public string Category { get; private set; }
        public string VectorIcon { get; private set; }
        public string WebSite { get; private set; }

        // Relacionamentos       
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        // Ctor
        protected ComponentThumbnail() { }

        public ComponentThumbnail(string userId, int siteNumber, Guid userImageGalleryId, string category = "", string icon = "", string webSite = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(category, icon, webSite); 

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.Category = category;
            this.VectorIcon = icon;
            this.WebSite = webSite;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, string category = "", string icon = "", string webSite = "")
        {
            Validate(category, icon, webSite);

            this.UserImageGalleryId = userImageGalleryId;
            this.Category = category;
            this.VectorIcon = icon;
            this.WebSite = webSite;
            this.LastChange = DateTime.Now;
        }

        private void Validate(string category, string icon, string webSite)
        {             
            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(webSite, 128, Errors.MaxLength);
        }
    }
}
