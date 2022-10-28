using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IContentDapperRepositoryBaseT1<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber, int maxPosition);
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod);

        // Async Methods
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition);
        Task<IEnumerable<TEntity>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod);
    }
}
