using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class AdminViewItemAppService : AppServiceBase<AdminViewItem>, IAdminViewItemAppService
    {
        private readonly IAdminViewItemService _adminViewItemService;

        public AdminViewItemAppService(IAdminViewItemService adminViewItemService)
            : base(adminViewItemService)
        {
            _adminViewItemService = adminViewItemService;
        }

        public IEnumerable<AdminViewItem> GetAllByViewDataId(int viewDataId)
        {
            return _adminViewItemService.GetAllByViewDataId(viewDataId);
        }
    }
}
