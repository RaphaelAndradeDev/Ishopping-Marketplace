using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;

namespace Ishopping.Infra.Data.Repositories
{
    public class ECommerceProductSoldRepository : RepositoryBaseT2<ECommerceProductSold>, IECommerceProductSoldRepository
    {
    }
}
