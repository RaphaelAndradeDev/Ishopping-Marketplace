using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IECommerceProductService : IServiceBaseT2<ECommerceProduct>
    {
        ECommerceProduct GetByImageId(string imageId);
    }
}
