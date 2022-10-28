using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IConfigUserViewItemRepository : IRepositoryBaseT2<ConfigUserViewItem>, IRepositoryIdentifiedGetAll<ConfigUserViewItem>
    {        
        bool ExistItem(string viewTipo, string userId);
        ConfigUserViewItem GetBy(string viewTipo, string userId);
        ConfigUserViewItem GetBy(int viewTypeCod, string userId);
        ConfigUserViewItem GetBy(Guid id, string userId);
        IEnumerable<ConfigUserViewItem> GetAllByUserId(string userId);
        IEnumerable<ConfigUserViewItem> GetAllBy(int viewCod, string userId);
        IEnumerable<GroupViewItem> GetAllUserViewItem(int viewCod, string userId);
        IEnumerable<int> GetAllAdminViewItemCod(string userId);        
    }
}
