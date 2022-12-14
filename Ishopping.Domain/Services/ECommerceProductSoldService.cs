using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class ECommerceProductSoldService : ServiceBaseT2<ECommerceProductSold>, IECommerceProductSoldService
    {
        private readonly IECommerceProductSoldRepository _eCommerceProductSoldRepository;

        public ECommerceProductSoldService(IECommerceProductSoldRepository eCommerceProductSoldRepository)
            : base(eCommerceProductSoldRepository)
        {
            _eCommerceProductSoldRepository = eCommerceProductSoldRepository;
        }
    }
}
