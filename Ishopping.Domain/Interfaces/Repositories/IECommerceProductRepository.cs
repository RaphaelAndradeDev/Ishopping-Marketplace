using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IECommerceProductRepository : IRepositoryBaseT2<ECommerceProduct>
    {
        ECommerceProduct GetByImageId(string imageId);
    }
}
