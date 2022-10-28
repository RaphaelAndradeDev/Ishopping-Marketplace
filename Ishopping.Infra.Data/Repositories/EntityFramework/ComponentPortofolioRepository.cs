using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPortofolioRepository : RepositoryBaseT2<ComponentPortofolio>, IComponentPortofolioRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentPortofolio.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentPortofolio GetByImageId(Guid imageId)
        {
            return db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentPortofolio GetBySiteNumber(int siteNumber)
        {
            return db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentPortofolio> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentPortofolio> GetAllByUserId(string userId)
        {
            return db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentPortofolio GetById(Guid id, string userId)
        {
            return db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentPortofolio GetBy(string search, int position, string userId)
        {
            return db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentPortofolio.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentPortofolio.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentPortofolio> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentPortofolio> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPortofolio> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentPortofolio> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentPortofolio.Include("ComponentPortofolioOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }


        // Async Methods for AppPortfolio
        public async Task<SimplePortfolio> GetByIdAsync(Guid id)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.Id == id && x.DisplayOnlyPage == false)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetBySiteNumberAsync(int siteNumber, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTitleAsync(int siteNumber, string title, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.Title.StartsWith(title))
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string category, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.Category == category)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string category, string subCategory, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.Category == category && x.SubCategory == subCategory)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }    

        // multiplus usuarios
        public async Task<IEnumerable<SimplePortfolio>> GetAllBySiteNumberAsync(IEnumerable<int> siteNumber, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => siteNumber.Contains(x.SiteNumber) && x.DisplayOnlyPage == false)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByTitleAsync(string title, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.DisplayOnlyPage == false && x.Title.StartsWith(title))
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string category, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.DisplayOnlyPage == false && x.Category == category)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string category, string subCategory, int take)
        {
            return await db.ComponentPortofolio.Include("UserImageGallery").Where(x => x.DisplayOnlyPage == false && x.Category == category && x.SubCategory == subCategory)
                .Select(x => new SimplePortfolio() { Id = x.Id, SiteNumber = x.SiteNumber, PortfolioHead = x.PortfolioHead, PortfolioChild = x.PortfolioChild, Category = x.Category, SubCategory = x.SubCategory, Title = x.Title, Description = x.Description,  Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }        

    }
}
