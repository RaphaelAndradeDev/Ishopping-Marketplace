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
    public class ECommerceProductCategoryService : ServiceBaseT2<ECommerceProductCategory>, IECommerceProductCategoryService
    {
        private readonly IECommerceProductCategoryRepository _eCommerceProductCategoryRepository;

        public ECommerceProductCategoryService(IECommerceProductCategoryRepository eCommerceProductCategoryRepository)
            : base(eCommerceProductCategoryRepository)
        {
            _eCommerceProductCategoryRepository = eCommerceProductCategoryRepository;
        }
    }
}
