using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IConfigUserViewItemService : IServiceBaseT2<ConfigUserViewItem>, IServiceIdentifiedGetAll<ConfigUserViewItem>
    {
        bool ExistItem(string viewTipo, string userId);
        ConfigUserViewItem GetBy(string viewTipo, string userId);
        ConfigUserViewItem GetBy(int viewItemCod, string userId);
        ConfigUserViewItem GetBy(Guid id, string userId);
        IEnumerable<ConfigUserViewItem> GetAllBy(int viewCod, string userId);
        IEnumerable<GroupViewItem> GetAllUserViewItem(int viewCod, string userId);
        IEnumerable<int> GetAllAdminViewItemCod(string userId);       
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, string userId);
        Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, int siteNumber);
        Task<IEnumerable<BasicUserViewItem>> GetAllBasicViewItemAsync(int[] viewTypeCod, int siteNumber);
    }
}
