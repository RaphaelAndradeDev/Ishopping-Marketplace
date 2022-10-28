using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentAppServiceBaseT2Async<TEntity> where TEntity : class
    {
        Task<IEnumerable<string>> SearchAsync(string startsWith, string userId);
        Task<TEntity> GetBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllByUserIdAsync(string userId);
        Task<TEntity> GetByIdAsync(Guid id, string userId);
        Task<TEntity> GetByTermAsync(string term, string userId);

        //void DeleteAll(string userId);
    }
}
