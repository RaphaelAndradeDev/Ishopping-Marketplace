using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class ECommerceProductCategoryAppService : AppServiceBaseT2<ECommerceProductCategory>, IECommerceProductCategoryAppService
    {
        private readonly IECommerceProductCategoryService _eCommerceProductCategoryService;

        public ECommerceProductCategoryAppService(IECommerceProductCategoryService eCommerceProductCategoryService)
            :base(eCommerceProductCategoryService)
        {
            _eCommerceProductCategoryService = eCommerceProductCategoryService;
        }
    }
}
