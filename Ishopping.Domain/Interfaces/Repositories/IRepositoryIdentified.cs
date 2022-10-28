
namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IRepositoryIdentified<TEntity> where TEntity : class
    {
        TEntity GetBySiteNumber(int siteNumber);        
    }
}
