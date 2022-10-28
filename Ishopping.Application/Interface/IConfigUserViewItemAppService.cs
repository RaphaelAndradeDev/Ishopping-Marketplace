using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IConfigUserViewItemAppService : IAppServiceBaseT2<ConfigUserViewItem>, IAppServiceIdentifiedGetAll<ConfigUserViewItem>
    {        
        bool ExistItem(string viewTipo, string userId);
        ConfigUserViewItem GetBy(string viewTipo, string userId);
        ConfigUserViewItem GetBy(int viewItemCod, string userId);
        IEnumerable<ConfigUserViewItem> GetAllBy(int viewCod, string userId);
        IEnumerable<GroupViewItem> GetAllUserViewItem(int viewCod, string userId);      
        void SetConfigUserViewItemOption(string textView, string styleTextView, string subTitle, string styleSubTitle, int viewItemCod, string userId);

        // Async Methods
        Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, string userId);
    }
}
