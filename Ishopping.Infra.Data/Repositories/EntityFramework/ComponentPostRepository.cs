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
    public class ComponentPostRepository : RepositoryBaseT2<ComponentPost>, IComponentPostRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentPost.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentPost GetByImageId(Guid imageId)
        {
            var userImageGallery = db.UserImageGallery.Find(imageId);
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }

        public ComponentPost GetBySiteNumber(int siteNumber)
        {
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentPost> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentPost> GetOrderByDate(int siteNumber, int take)
        {
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber && x.DisplayOnPage == true).OrderByDescending(d => d.DataCadastro).Take(take);
        }

        public IEnumerable<ComponentPost> GetAllByUserId(string userId)
        {
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentPost GetBy(Guid id)
        {            
            return db.ComponentPost.Include("UserImageGallery").FirstOrDefault(b => b.Id == id);
        }

        public ComponentPost GetById(Guid id, string userId)
        {
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentPost GetByTerm(string search, string userId)
        {
            return db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }               

        public void AddBy(ComponentPost componentPost)
        {
            var ids = componentPost.UserImageGallery.Select(x => x.Id);
            var listUserImageGallery = db.UserImageGallery.Where(x => ids.Contains(x.Id)).ToList();
            componentPost.AddListUserImageGallery(listUserImageGallery);
            db.ComponentPost.Add(componentPost);
            db.SaveChanges();
        }
        
        public void UpdateBy(ComponentPost componentPost)
        {
            List<Guid> ids = componentPost.UserImageGallery.Select(x => x.Id).ToList();
            var listUserImageGallery = db.UserImageGallery.Where(x => ids.Contains(x.Id)).ToList();
            componentPost.AddListUserImageGallery(listUserImageGallery);
            db.Entry(componentPost).State = EntityState.Modified;
            db.SaveChanges(); 
        }           
        
        public IEnumerable<string> GetAllCategory()
        {
            return db.ComponentPost.Where(x => x.IsBlock == false).Select(x => x.Categoria).Distinct();
        }               

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentPost.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentPost.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> SearchAsync(string startsWith)
        {
            return await db.ComponentPost.Where(x => x.Search.StartsWith(startsWith) && x.IsBlock == false).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentPost> GetByImageIdAsync(Guid imageId)
        {
            var userImageGallery = await db.UserImageGallery.FindAsync(imageId);
            return await db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }

        public async Task<ComponentPost> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentPost>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentPost>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPost> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentPost> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentPost.Include("ComponentPostOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

        public async Task<IEnumerable<string>> GetAllCategoryAsync()
        {
            return await db.ComponentPost.Where(x => x.IsBlock == false).Select(x => x.Categoria).Distinct().ToListAsync();
        }


        // Async Methods for SinglePost
        public async Task<SinglePost> GetSinglePostByIdAsync(Guid id)
        {
            return await db.ComponentPost.Include("UserImageGallery").Where(x => x.Id == id && x.DisplayOnlyPage == false)
                .Select(x => new SinglePost() { Id = x.Id, SiteNumber = x.SiteNumber, Model = x.Model, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, SubTitulo2 = x.SubTitulo2, Paragrafo2 = x.Paragrafo2, SubTitulo3 = x.SubTitulo3, Paragrafo3 = x.Paragrafo3, Video = x.Video, Tags = x.Tags, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).FirstOrDefaultAsync();
        }

        // Async Methods for SimplePost
        public async Task<IEnumerable<SimplePost>> GetAllBySiteNumberAsync(int siteNumber, int take)
        {
            return await db.ComponentPost.Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.IsBlock == false).OrderBy(x => x.Views).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int take)
        {
            return await db.ComponentPost.Where(x => x.IsBlock == false && x.DisplayOnlyPage == false).OrderByDescending(x => x.DataCadastro).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int siteNumber, int take)
        {
            return await db.ComponentPost.Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.IsBlock == false).OrderBy(x => x.DataCadastro).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(string category, int take)
        {
            return await db.ComponentPost.Where(x => x.Categoria == category && x.DisplayOnlyPage == false && x.IsBlock == false).OrderBy(x => x.DataCadastro).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int take)
        {
            return await db.ComponentPost.Where(x => x.Categoria == category && x.DisplayOnlyPage == false && x.IsBlock == false).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int siteNumber, int take)
        {
            return await db.ComponentPost.Where(x => x.Categoria == category && x.DisplayOnlyPage == false && x.SiteNumber == siteNumber && x.IsBlock == false).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int take)
        {
            return await db.ComponentPost.Where(x => x.IsBlock == false && x.DisplayOnlyPage == false).OrderBy(x => x.Views).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int siteNumber, int take)
        {
            return await db.ComponentPost.Where(x => x.SiteNumber == siteNumber && x.DisplayOnlyPage == false && x.IsBlock == false).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term)
        {
            return await db.ComponentPost.Where(x => x.Search == term && x.DisplayOnlyPage == false && x.IsBlock == false).Include("UserImageGallery")
                .Select(x => new SimplePost() { Id = x.Id, SiteNumber = x.SiteNumber, Autor = x.Autor, Categoria = x.Categoria, Titulo = x.Titulo, SubTitulo1 = x.SubTitulo1, Paragrafo1 = x.Paragrafo1, DataCadastro = x.DataCadastro, Views = x.Views, UserImageGallery = x.UserImageGallery }).Take(36).ToListAsync();
        }
    }
}
