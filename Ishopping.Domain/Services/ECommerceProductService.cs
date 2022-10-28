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
    public class ECommerceProductService : ServiceBaseT2<ECommerceProduct>, IECommerceProductService
    {
        private readonly IECommerceProductRepository _eCommerceProductRepository;

        public ECommerceProductService(IECommerceProductRepository eCommerceProductRepository)
            : base(eCommerceProductRepository)
        {
            _eCommerceProductRepository = eCommerceProductRepository;
        }

        public ECommerceProduct GetByImageId(string imageId)
        {
            return _eCommerceProductRepository.GetByImageId(imageId);
        }
    }
}
