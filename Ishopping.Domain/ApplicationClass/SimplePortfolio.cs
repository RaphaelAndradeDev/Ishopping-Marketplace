using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Domain.ApplicationClass
{
    public class SimplePortfolio
    {
        public Guid Id { get; set; }
        public int SiteNumber { get; set; }     
        public bool DisplayOnPage { get; set; }
        public bool DisplayOnlyPage { get; set; }
        public bool PortfolioHead { get; set; }
        public bool PortfolioChild { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        // Get IsTags
        public IEnumerable<string> _Tags { get { return IsTags.Split(Tags); } }
        public string _Title { get { return IsHtmlTags.RemoveTags(Title); } }
        public string _Description { get { return IsHtmlTags.RemoveTags(Description); } } 

        // Relacionamentos    
        public virtual UserImageGallery UserImageGallery { get; set; }

        public SimplePortfolio(){}

        public SimplePortfolio(Guid id, int siteNumber, bool portfolioHead, bool portfolioChild, string category, string subCategory, string title, string description, string tags, UserImageGallery userImageGallery)
        {
            Id = id;
            SiteNumber = siteNumber;
            PortfolioHead = portfolioHead;
            PortfolioChild = portfolioChild;
            Category = category;
            SubCategory = subCategory;
            Title = title;
            Description = description;
            Tags = tags;
            UserImageGallery = userImageGallery;        
        }
    }
}
