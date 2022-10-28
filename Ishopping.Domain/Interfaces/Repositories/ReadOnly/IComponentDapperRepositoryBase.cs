using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IComponentDapperRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber);
    }
}
