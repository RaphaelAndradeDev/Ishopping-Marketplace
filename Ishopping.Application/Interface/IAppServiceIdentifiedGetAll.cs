using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IAppServiceIdentifiedGetAll<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
    }
}
