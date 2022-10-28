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
    public class ECommerceShoppingListService : ServiceBaseT2<ECommerceShoppingList>, IECommerceShoppingListService
    {
        private readonly IECommerceShoppingListRepository _eCommerceShoppingListRepository;

        public ECommerceShoppingListService(IECommerceShoppingListRepository eCommerceShoppingListRepository)
            : base(eCommerceShoppingListRepository)
        {
            _eCommerceShoppingListRepository = eCommerceShoppingListRepository;
        }
    }
}
