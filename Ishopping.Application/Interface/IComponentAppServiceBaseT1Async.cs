using Ishopping.Domain.ApplicationClass;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentAppServiceBaseT1Async<TEntity> where TEntity : class
    {
        Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId);
        Task<TEntity> GetBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllByUserIdAsync(string userId);
        Task<TEntity> GetByIdAsync(Guid id, string userId);
        Task<TEntity> GetByAsync(string search, int position, string userId);

        //void DeleteAll(string userId);
    }
}
