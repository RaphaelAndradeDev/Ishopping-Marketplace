using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IRepositoryIdentifiedGetAll<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
    }
}
