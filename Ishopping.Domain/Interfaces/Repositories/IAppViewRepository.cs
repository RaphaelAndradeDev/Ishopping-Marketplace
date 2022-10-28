using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IAppViewRepository : IRepositoryBase<AppView>
    {
        IEnumerable<AppView> GetAllByType(int type);
    }
}
