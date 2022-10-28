using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPostService : IServiceBaseT2<ComponentPost>, IComponentServiceBaseT2<ComponentPost>, IComponentServiceBaseT2Async<ComponentPost>
    {
        ComponentPost GetBy(Guid id);
        void AddBy(ComponentPost componentPost);
        ComponentPost GetByImageId(Guid imageId);        
        void UpdateBy(ComponentPost componentPost);
        IEnumerable<ComponentPost> GetOrderByDate(int siteNumber, int take);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith);
        Task<ComponentPost> GetByImageIdAsync(Guid imageId);
        Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term);
        Task<IEnumerable<string>> GetAllCategoryAsync();

        // Async Methods for SinglePost
        Task<SinglePost> GetSinglePostByIdAsync(Guid id);

        // Async Methods for SimplePost
        Task<IEnumerable<SimplePost>> GetAllBySiteNumberAsync(int siteNumber, int take);
        Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int take);
        Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int siteNumber, int take);
        Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(string category, int take);     
        Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int take);
        Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int siteNumber, int take);
        Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int take);
        Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int siteNumber, int take);
    }
}
