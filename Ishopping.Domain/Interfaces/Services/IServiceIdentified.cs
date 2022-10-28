
namespace Ishopping.Domain.Interfaces.Services
{
    public interface IServiceIdentified<TEntity> where TEntity : class
    {
        TEntity GetBySiteNumber(int siteNumber);
    }
}
