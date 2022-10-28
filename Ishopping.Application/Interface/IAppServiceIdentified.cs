using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IAppServiceIdentified<TEntity> where TEntity : class
    {
        TEntity GetBySiteNumber(int siteNumber);
    }
}
