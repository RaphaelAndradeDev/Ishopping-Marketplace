using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentPortofolio : _Component
    {
        public bool DisplayOnPage { get; private set; }
        public bool DisplayOnlyPage { get; private set; }
        public bool PortfolioHead { get; private set; }
        public bool PortfolioChild { get; private set; }
        public int Position { get; private set; }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
        public string Title { get; private set; }  
        public string Description { get; private set; }
        public string Tags { get; private set; }
        public string List { get; private set; }
        public bool Ordered { get; private set; }           // lista ordenada = true, não ordenada = false

        // Get IsTags
        public string _Tags { get { return IsTags.Format(Tags); } }
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }
        public string _List { get { return IsHtmlTags.GetTags(List); } }  


        // Relacionamentos     
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public Guid ComponentPortofolioOptionId { get; private set; }
        public virtual ComponentPortofolioOption ComponentPortofolioOption { get; private set; }

        // Ctor
        protected ComponentPortofolio() { }

        public ComponentPortofolio(string userId, int siteNumber, Guid userImageGalleryId, Guid componentPortofolioOptionId, bool displayOnPage, bool displayOnlyPage, bool portfolioHead, bool portfolioChild,
            string title, string description = "", string category = "", string subCategory = "", string list = "", bool ordered = false, int position = 1, string tags = "")
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(title, description, category, subCategory, list, position, tags);

            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            PortfolioHead = portfolioHead;
            PortfolioChild = portfolioChild;
            SiteNumber = siteNumber;
            IdUser = userId;
            UserImageGalleryId = userImageGalleryId;
            ComponentPortofolioOptionId = componentPortofolioOptionId;
            Category = category;
            SubCategory = subCategory;
            List = list;
            Ordered = ordered;
            Position = position;
            Tags = IsTags.Join(tags);
            LastChange = DateTime.Now;

            Title = IsHtmlTags.SetTags(title);
            Search = IsHtmlTags.RemoveTags(title);
            Description = IsHtmlTags.SetTags(description);
            List = IsHtmlTags.SetTags(list);
        }

        public ComponentPortofolio(string userId, int siteNumber, Guid userImageGalleryId, ComponentPortofolioOption componentPortofolioOption, bool displayOnPage, bool displayOnlyPage, bool portfolioHead, bool portfolioChild,
            string title, string description = "", string category = "", string subCategory = "", string list = "", bool ordered = false, int position = 1, string tags = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, description, category, subCategory, list, position, tags);

            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            PortfolioHead = portfolioHead;
            PortfolioChild = portfolioChild;
            SiteNumber = siteNumber;
            IdUser = userId;
            UserImageGalleryId = userImageGalleryId;
            ComponentPortofolioOption = componentPortofolioOption;
            Category = category;
            SubCategory = subCategory;
            List = list;
            Ordered = ordered;
            Position = position;
            Tags = IsTags.Join(tags);
            LastChange = DateTime.Now;

            Title = IsHtmlTags.SetTags(title);
            Search = IsHtmlTags.RemoveTags(title);
            Description = IsHtmlTags.SetTags(description);
            List = IsHtmlTags.SetTags(list);
        }

        // Methods
        public void AddComponentPortofolioOption(ComponentPortofolioOption componentPortofolioOption)
        {
            ComponentPortofolioOption = componentPortofolioOption;
        }

        public void ChangeComponentPortofolioOption(Guid componentPortofolioOptionId)
        {
            ComponentPortofolioOptionId = componentPortofolioOptionId;
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, bool displayOnPage, bool displayOnlyPage, bool portfolioHead, bool portfolioChild, string title, string description = "", string category = "", string subCategory = "", string list = "", bool ordered = false, int position = 1, string tags = "")
        {
            Validate(title, description, category, subCategory, list, position, tags);

            UserImageGalleryId = userImageGalleryId;
            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            PortfolioHead = portfolioHead;
            PortfolioChild = portfolioChild;
            Category = category;
            SubCategory = subCategory;
            List = list;
            Ordered = ordered;
            Position = position;
            Tags = IsTags.Join(tags);

            Title = IsHtmlTags.SetTags(title);
            Search = IsHtmlTags.RemoveTags(title);
            Description = IsHtmlTags.SetTags(description);
            List = IsHtmlTags.SetTags(list);
        }

        // Validadte
        private void Validate(string title, string description, string category, string subCategory, string list, int position, string tags)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(subCategory, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(list, 256, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentLength(tags, 320, Errors.MaxLength);
        }
    }
}
