using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class ECommerceProductSoldAppService : AppServiceBaseT2<ECommerceProductSold>, IECommerceProductSoldAppService
    {
        private readonly IECommerceProductSoldService _eCommerceProductSoldService;

        public ECommerceProductSoldAppService(IECommerceProductSoldService eCommerceProductSoldService)
            :base(eCommerceProductSoldService)
        {
            _eCommerceProductSoldService = eCommerceProductSoldService;
        }
    }
}
