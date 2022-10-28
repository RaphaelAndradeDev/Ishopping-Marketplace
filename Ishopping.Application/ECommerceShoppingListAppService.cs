using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class ECommerceShoppingListAppService : AppServiceBaseT2<ECommerceShoppingList>, IECommerceShoppingListAppService
    {
        private readonly IECommerceShoppingListService _eCommerceShoppingListService;

        public ECommerceShoppingListAppService(IECommerceShoppingListService eCommerceShoppingListService)
            :base(eCommerceShoppingListService)
        {
            _eCommerceShoppingListService = eCommerceShoppingListService;
        }
    }
}
