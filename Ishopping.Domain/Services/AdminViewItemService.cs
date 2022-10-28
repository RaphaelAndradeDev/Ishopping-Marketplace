using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AdminViewItemService : ServiceBase<AdminViewItem>, IAdminViewItemService
    {
        private readonly IAdminViewItemRepository _adminViewItemRepository;

        public AdminViewItemService(IAdminViewItemRepository adminViewItemRepository)
            : base(adminViewItemRepository)
        {
            _adminViewItemRepository = adminViewItemRepository;
        }

        public IEnumerable<AdminViewItem> GetAllByViewDataId(int viewDataId)
        {
            return _adminViewItemRepository.GetAllByViewDataId(viewDataId);
        }
        
        public IEnumerable<int> GetAllViewItemCod(int templateCod)
        {
            return _adminViewItemRepository.GetAllViewItemCod(templateCod);
        }
    }
}
