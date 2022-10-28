using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IComponentPostDapperRepository : IComponentDapperRepositoryBase<ComponentPost>
    {
        // Async Methods for SimplePost
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
        Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term);
    }
}
