using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentMenu : _Component
    {       
        public string Category { get; private set; }
        public string Title { get; private set; }       
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool IsDynamic { get; private set; }
        public string DayOfWeek { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        // Relacionamentos       
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public Guid ComponentMenuOptionId { get; private set; }
        public virtual ComponentMenuOption ComponentMenuOption { get; private set; }

        // Ctor
        protected ComponentMenu() { }

        public ComponentMenu(string userId, int siteNumber, Guid userImageGalleryId, Guid componentMenuOptionId,
            string title, decimal price, string category = "", string description = "", string dayOfWeek = "", bool isDynamic = false)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, price, category, description, dayOfWeek);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentMenuOptionId = componentMenuOptionId;
            this.Price = price;
            this.Category = category;
            this.DayOfWeek = dayOfWeek;
            this.IsDynamic = isDynamic;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentMenu(string userId, int siteNumber, Guid userImageGalleryId, ComponentMenuOption componentMenuOption,
            string title, decimal price, string category = "", string description = "", string dayOfWeek = "", bool isDynamic = false)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, price, category, description, dayOfWeek);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentMenuOption = componentMenuOption;
            this.Price = price;
            this.Category = category;
            this.DayOfWeek = dayOfWeek;
            this.IsDynamic = isDynamic;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }
        
        // Methods
        public void AddComponentMenuOption(ComponentMenuOption componentMenuOption)
        {
            this.ComponentMenuOption = componentMenuOption;
        }

        public void ChangeComponentMenuOption(Guid componentMenuOptionId)
        {
            this.ComponentMenuOptionId = componentMenuOptionId;
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, Guid componentMenuOptionId,
            string title, decimal price, string category = "", string description = "", string dayOfWeek = "", bool isDynamic = false)
        {
            Validate(title, price, category, description, dayOfWeek);

            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentMenuOptionId = componentMenuOptionId;
            this.Price = price;
            this.Category = category;
            this.DayOfWeek = dayOfWeek;
            this.IsDynamic = isDynamic;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string title, decimal price, string category, string description, string dayOfWeek)
        {           
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(price, 0, 99999, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentLength(category, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(dayOfWeek, 32, Errors.MaxLength);
        }
    }
}
