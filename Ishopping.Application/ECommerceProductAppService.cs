using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class ECommerceProductAppService : AppServiceBaseT2<ECommerceProduct>, IECommerceProductAppService
    {
        private readonly IECommerceProductService _eCommerceProductService;

        public ECommerceProductAppService(IECommerceProductService eCommerceProductService)
            :base(eCommerceProductService)
        {
            _eCommerceProductService = eCommerceProductService;
        }

        public ECommerceProduct GetByImageId(string imageId)
        {
            return _eCommerceProductService.GetByImageId(imageId);
        }
    }
}
