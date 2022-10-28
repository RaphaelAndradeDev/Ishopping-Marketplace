using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.ApplicationClass
{
    public class SimpleProduct
    {
        public Guid Id { get; set; }
        public int SiteNumber { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Tags { get; set; }

        public SimpleProduct()
        {

        }

        public SimpleProduct(Guid id, int siteNumber, int category, int subCategory, string brand, decimal price)
        {
            Id = id;
            SiteNumber = siteNumber;
            Category = category;
            SubCategory = subCategory;
            Brand = brand;
            Price = price;
        }

        public SimpleProduct(Guid id, int siteNumber, int category, int subCategory, string name, string brand, string model, string description, decimal price, string tags, ICollection<UserImageGallery> userImageGallery)
        {
            Id = id;
            SiteNumber = siteNumber;
            Category = category;
            SubCategory = subCategory;
            Name = name;
            Brand = brand;
            Model = model;
            Description = description;
            Price = price;
            Tags = tags;
            UserImageGallery = userImageGallery;
        }

        public BasicCategory _Category { get {
                return new BasicCategory(Category, BasicCategoryList.getCategoryByKey(Category));
            }
        }
        public BasicCategory _SubCategory { get {
                return new BasicCategory(SubCategory, BasicCategoryList.getSubCategoryByKey(SubCategory));
            }
        }

        // Relacionamentos       
        public virtual ICollection<UserImageGallery> UserImageGallery { get; set; }
        
        // Private Methos
        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            UserImageGallery.Add(userImageGallery);
        }
    }
}
