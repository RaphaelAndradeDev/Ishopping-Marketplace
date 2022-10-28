using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IConfigUserViewItemDapperRepository 
    {
        IEnumerable<ConfigUserViewItem> GetAllBySiteNumber(int siteNumber);
        Task<IEnumerable<ConfigUserViewItem>> GetAllBySiteNumberAsync(int siteNumber);
        Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, string userId);
        Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, int siteNumber);
        Task<IEnumerable<BasicUserViewItem>> GetAllBasicViewItemAsync(int[] viewTypeCod, int siteNumber);
    }
}
