using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IServiceIdentifiedGetAll<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
    }
}
