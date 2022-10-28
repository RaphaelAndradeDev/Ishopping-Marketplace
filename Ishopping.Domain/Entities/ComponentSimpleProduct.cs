using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentSimpleProduct : _Component
    {
        public bool DisplayOnPage { get; private set; }
        public bool DisplayOnlyPage { get; private set; }
        public string Name { get; private set; }   
        public int Category { get; private set; }
        public int SubCategory { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Tags { get; private set; }

        // Get IsTags
        public string _Tags { get { return IsTags.Format(Tags); } }
        public string _Name { get { return IsHtmlTags.GetTags(Name); } }
        public string _Brand { get { return IsHtmlTags.GetTags(Brand); } }
        public string _Model { get { return IsHtmlTags.GetTags(Model); } }  
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }


        // Relacionamentos       
        public virtual ICollection<UserImageGallery> UserImageGallery { get; private set; }

        public Guid ComponentSimpleProductOptionId { get; private set; }
        public virtual ComponentSimpleProductOption ComponentSimpleProductOption { get; private set; }

        // Ctor
        protected ComponentSimpleProduct() { }

        public ComponentSimpleProduct(string userId, int siteNumber, ICollection<UserImageGallery> userImageGallery, Guid componentSimpleProductOptionId, bool displayOnPage, bool displayOnlyPage,
            string name, decimal price, int category, int subCategory, string brand = "", string model = "", string description = "", string tags = "")
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(name, category, subCategory, brand, model, description, price, tags); 

            SiteNumber = siteNumber;
            IdUser = userId;
            UserImageGallery = userImageGallery;
            ComponentSimpleProductOptionId = componentSimpleProductOptionId;
            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            Category = category;
            SubCategory = subCategory;
            Price = price;
            Tags = IsTags.Join(tags);
            LastChange = DateTime.Now;            

            Name = IsHtmlTags.SetTags(name);
            Search = IsHtmlTags.RemoveTags(name);
            Brand = IsHtmlTags.SetTags(brand);
            Model = IsHtmlTags.SetTags(model);
            Description = IsHtmlTags.SetTags(description);
        }

        public ComponentSimpleProduct(string userId, int siteNumber, ICollection<UserImageGallery> userImageGallery, ComponentSimpleProductOption componentSimpleProductOption, bool displayOnPage, bool displayOnlyPage,
            string name, decimal price, int category, int subCategory, string brand = "", string model = "", string description = "", string tags = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(name, category, subCategory, brand, model, description, price, tags);

            SiteNumber = siteNumber;
            IdUser = userId;
            UserImageGallery = userImageGallery;
            ComponentSimpleProductOption = componentSimpleProductOption;
            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            Category = category;
            SubCategory = subCategory;
            Price = price;
            Tags = IsTags.Join(tags);
            LastChange = DateTime.Now;

            Name = IsHtmlTags.SetTags(name);
            Search = IsHtmlTags.RemoveTags(name);
            Brand = IsHtmlTags.SetTags(brand);
            Model = IsHtmlTags.SetTags(model);
            Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentSimpleProductOption(ComponentSimpleProductOption componentSimpleProductOption)
        {
            ComponentSimpleProductOption = componentSimpleProductOption;
        }

        public void ChangeComponentSimpleProductOption(Guid componentSimpleProductOptionId)
        {
            ComponentSimpleProductOptionId = componentSimpleProductOptionId;
        }

        public void AddListUserImageGallery(ICollection<UserImageGallery> userImageGallery)
        {
            UserImageGallery = userImageGallery;
        }

        public void Change(ICollection<UserImageGallery> userImageGallery, bool displayOnPage, bool displayOnlyPage, string name, decimal price, int category, int subCategory, string brand = "", string model = "", string description = "", string tags = "")
        {
            Validate(name, category, subCategory, brand, model, description, price, tags); 

            UserImageGallery = userImageGallery;
            DisplayOnlyPage = displayOnlyPage;
            Category = category;
            Price = price;
            Tags = IsTags.Join(tags);
            LastChange = DateTime.Now;

            Name = IsHtmlTags.SetTags(name);
            Search = IsHtmlTags.RemoveTags(name);
            Brand = IsHtmlTags.SetTags(brand);
            Model = IsHtmlTags.SetTags(model);
            Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string name, int category, int subCategory, string brand, string model, string description, decimal price, string tags)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(category, 10, 99, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentRange(subCategory, 1001, 9999, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentLength(brand, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(model, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(price, 0, 99999, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentLength(tags, 320, Errors.MaxLength);
        }
    }
}
