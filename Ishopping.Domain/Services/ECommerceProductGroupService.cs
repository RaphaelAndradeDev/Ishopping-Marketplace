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
    public class ECommerceProductGroupService : ServiceBaseT2<ECommerceProductGroup>, IECommerceProductGroupService
    {
        private readonly IECommerceProductGroupRepository _eCommerceProductGroupRepository;

        public ECommerceProductGroupService(IECommerceProductGroupRepository eCommerceProductGroupRepository)
            : base(eCommerceProductGroupRepository)
        {
            _eCommerceProductGroupRepository = eCommerceProductGroupRepository;
        }
    }
}
