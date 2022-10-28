using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class ECommerceProductGroupAppService : AppServiceBaseT2<ECommerceProductGroup>, IECommerceProductGroupAppService
    {
        private readonly IECommerceProductGroupService _eCommerceProductGroupService;

        public ECommerceProductGroupAppService(IECommerceProductGroupService eCommerceProductGroupService)
            :base(eCommerceProductGroupService)
        {
            _eCommerceProductGroupService = eCommerceProductGroupService;
        }
    }
}
