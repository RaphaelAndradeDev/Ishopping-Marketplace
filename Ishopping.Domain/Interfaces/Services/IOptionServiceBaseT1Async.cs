using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IOptionServiceBaseT1Async<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllByUserIdAsync(string userId);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, string userId);
        Task<TEntity> GetDefaultAsync(string userId);
    }
}
