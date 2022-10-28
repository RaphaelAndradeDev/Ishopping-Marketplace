using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AppViewRepository : RepositoryBase<AppView>, IAppViewRepository
    {
        public IEnumerable<AppView> GetAllByType(int type)
        {
            return db.AppView.Where(x => x.Type == type);
        }
    }
}
