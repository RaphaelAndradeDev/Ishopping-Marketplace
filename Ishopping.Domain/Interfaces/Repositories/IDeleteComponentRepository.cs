using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IDeleteComponentRepository
    {
        List<int> DeleteComponent(string userId, IEnumerable<int> viewItemCod);
    }
}
