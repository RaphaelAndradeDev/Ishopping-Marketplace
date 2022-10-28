using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminViewItemRepository : RepositoryBase<AdminViewItem>, IAdminViewItemRepository
    {
        public IEnumerable<AdminViewItem> GetAllByViewDataId(int viewDataId)
        {
            return db.AdminViewItem.Include("AdminViewData").Where(x => x.AdminViewData.Id == viewDataId);
        }
        
        public IEnumerable<int> GetAllViewItemCod(int templateCod)
        {
            return db.AdminViewItem.Include("AdminViewData.AdminTemplate").Where(x => x.AdminViewData.AdminTemplate.TemplateCod == templateCod)
                .Select(x => x.ViewTypeCod).Distinct().ToList();
        }
    }
}
