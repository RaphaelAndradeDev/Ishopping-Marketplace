using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentRepositoryBaseT1Async<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod);
        Task<IEnumerable<TEntity>> GetAllByUserIdAsync(string userId);
        Task<IEnumerable<TEntity>> GetAllByUserIdAsync(string userId, int maxPosition);
        Task<IEnumerable<TEntity>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod);
        Task<TEntity> GetByIdAsync(Guid id, string userId);
        Task<TEntity> GetByAsync(int viewCod, int position, string userId);
    }
}
