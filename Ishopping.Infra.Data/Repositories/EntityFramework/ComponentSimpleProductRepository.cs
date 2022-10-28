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
    public class ComponentSimpleProductRepository : RepositoryBaseT2<ComponentSimpleProduct>, IComponentSimpleProductRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentSimpleProduct.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentSimpleProduct GetByImageId(Guid imageId)
        {
            var userImageGallery = db.UserImageGallery.Find(imageId);
            return db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }

        public ComponentSimpleProduct GetBySiteNumber(int siteNumber)
        {
            return db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentSimpleProduct> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentSimpleProduct> GetAllByUserId(string userId)
        {
            return db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentSimpleProduct GetById(Guid id, string userId)
        {
            return db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentSimpleProduct GetByTerm(string search, string userId)
        {
            return db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void AddBy(ComponentSimpleProduct componentSimpleProduct)
        {
            {
                var ids = componentSimpleProduct.UserImageGallery.Select(x => x.Id);
                var listUserImageGallery = db.UserImageGallery.Where(x => ids.Contains(x.Id)).ToList();
                componentSimpleProduct.AddListUserImageGallery(listUserImageGallery);
                db.ComponentSimpleProduct.Add(componentSimpleProduct);
                db.SaveChanges();
            }
        }

        public void UpdateBy(ComponentSimpleProduct componentSimpleProduct)
        {
            List<Guid> ids = componentSimpleProduct.UserImageGallery.Select(x => x.Id).ToList();
            var listUserImageGallery = db.UserImageGallery.Where(x => ids.Contains(x.Id)).ToList();
            componentSimpleProduct.AddListUserImageGallery(listUserImageGallery);
            db.Entry(componentSimpleProduct).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentSimpleProduct.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentSimpleProduct.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId)
                .Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentSimpleProduct> GetByImageIdAsync(Guid imageId)
        {
            var userImageGallery = await db.UserImageGallery.FindAsync(imageId);
            return await db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }

        public async Task<ComponentSimpleProduct> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSimpleProduct> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentSimpleProduct> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentSimpleProduct.Include("ComponentSimpleProductOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }


        // Async Methods for AppStore  
        public async Task<SimpleProduct> GetByIdAsync(int siteNumber, Guid id) 
        {
            return await db.ComponentSimpleProduct.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.Id == id && x.DisplayOnlyPage == false)
                .Select(x => new SimpleProduct() { Brand = x.Brand, Category = x.Category, Description = x.Description, Model = x.Model, Name = x.Name, Price = x.Price, SubCategory = x.SubCategory, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Guid>> GetListProductIdAsync(int siteNumber, int take)
        {
            return await db.ComponentSimpleProduct.Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false).Select(x => x.Id).ToListAsync();
                
        }

        public async Task<IEnumerable<SimpleProduct>> GetByTitleAsync(int siteNumber, string name, int take)
        {
            return await db.ComponentSimpleProduct.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.Name.StartsWith(name))
                .Select(x => new SimpleProduct() { Brand = x.Brand, Category = x.Category, Description = x.Description, Model = x.Model, Name = x.Name, Price = x.Price, SubCategory = x.SubCategory, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimpleProduct>> GetByCategoryAsync(int siteNumber, int category, int take)
        {
            return await db.ComponentSimpleProduct.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.Category == category)
                .Select(x => new SimpleProduct() { Brand = x.Brand, Category = x.Category, Description = x.Description, Model = x.Model, Name = x.Name, Price = x.Price, SubCategory = x.SubCategory, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimpleProduct>> GetBySubCategoryAsync(int siteNumber, int subCategory, int take)
        {
            return await db.ComponentSimpleProduct.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.SubCategory == subCategory)
                .Select(x => new SimpleProduct() { Brand = x.Brand, Category = x.Category, Description = x.Description, Model = x.Model, Name = x.Name, Price = x.Price, SubCategory = x.SubCategory, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }            


        // Store for multiples user
        public async Task<IEnumerable<string>> SearchAsync(IEnumerable<int> siteNumber, string terms, int take)
        {
            return await db.ComponentSimpleProduct.Where(x => siteNumber.Contains(x.SiteNumber) && x.Search.StartsWith(terms) && x.DisplayOnlyPage == false)
                .Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }       

        public async Task<StoreDataPage> GetStoreDataPageAsync(List<BasicDisplay> basicDisplay, StoreFilter storeFilter, int take)
        {
            var basic = basicDisplay.Select(y => y.SiteNumber);
            var simpleProducts = new List<ComponentSimpleProduct>();
            
            if(storeFilter.Term != "")
            {
                simpleProducts = await db.ComponentSimpleProduct.Where(x => basic.Contains(x.SiteNumber) && x.Name.StartsWith(storeFilter.Term) && x.DisplayOnlyPage == false).ToListAsync();
            }
            else if(storeFilter.CategoryIsValid())
            {
                simpleProducts = await db.ComponentSimpleProduct.Where(x => basic.Contains(x.SiteNumber) && storeFilter.Category.Contains(x.Category) && x.DisplayOnlyPage == false).ToListAsync();
            }
            else if(storeFilter.SubCategory.ElementAt(0) != 0)
            {
                simpleProducts = await db.ComponentSimpleProduct.Where(x => basic.Contains(x.SiteNumber) && storeFilter.SubCategory.Contains(x.SubCategory) && x.DisplayOnlyPage == false).ToListAsync();
            }
            else
            {
                simpleProducts = await db.ComponentSimpleProduct.Where(x => basic.Contains(x.SiteNumber) && x.DisplayOnlyPage == false).ToListAsync();
            }            
            basicDisplay.ForEach(x => x.AddProductDataPage(simpleProducts.Where(y => y.SiteNumber == x.SiteNumber).Select(y => new ProductDataPage(y.Id, y.Category, y.SubCategory, y.Brand, y.Price)), storeFilter));
            return new StoreDataPage(basicDisplay);
        } 

        public async Task<IEnumerable<SimpleProduct>> GetAllByIdAsync(IEnumerable<Guid> id, int take)
        {
            return await db.ComponentSimpleProduct.Include("UserImageGallery").Where(x => id.Contains(x.Id) && x.DisplayOnlyPage == false)
                .Select(x => new SimpleProduct() { Id = x.Id, SiteNumber = x.SiteNumber, Brand = x.Brand, Category = x.Category, Description = x.Description, Model = x.Model, Name = x.Name, Price = x.Price, SubCategory = x.SubCategory, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }    

        public async Task<IEnumerable<SimpleProduct>> GetAllByCategoryAsync(IEnumerable<int> siteNumber, IEnumerable<int> category, int take)
        {
            return await db.ComponentSimpleProduct.Include("UserImageGallery").Where(x => siteNumber.Contains(x.SiteNumber) && x.DisplayOnlyPage == false && category.Contains(x.Category))
                .Select(x => new SimpleProduct() { Brand = x.Brand, Category = x.Category, Description = x.Description, Model = x.Model, Name = x.Name, Price = x.Price, SubCategory = x.SubCategory, Tags = x.Tags, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }
        
        // Private Methods
        private IEnumerable<BasicCategory> CategoryFilter(IEnumerable<int> categorys)
        {
            return new CategoryList().Category.Where(x => categorys.Distinct().Take(3).Contains(x.Id)).Select(x=> new BasicCategory(x.Id, x.Name));           
        }              
    }
}
