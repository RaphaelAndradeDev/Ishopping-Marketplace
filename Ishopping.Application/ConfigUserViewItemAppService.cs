using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ConfigUserViewItemAppService : AppServiceBaseT2<ConfigUserViewItem>, IConfigUserViewItemAppService
    {
        private readonly IConfigUserViewItemService _configUserViewItemService; 

        public ConfigUserViewItemAppService(
            IConfigUserViewItemService configUserViewItemService)
            :base(configUserViewItemService)
        {
            _configUserViewItemService = configUserViewItemService;           
        }

        public IEnumerable<ConfigUserViewItem> GetAllBySiteNumber(int siteNumber)
        {
            return _configUserViewItemService.GetAllBySiteNumber(siteNumber);
        }

        public bool ExistItem(string viewTipo, string userId)
        {
            return _configUserViewItemService.ExistItem(viewTipo, userId);
        }

        public IEnumerable<ConfigUserViewItem> GetAllBy(int viewCod, string userId)
        {
            return _configUserViewItemService.GetAllBy(viewCod, userId);
        }
        
        public IEnumerable<GroupViewItem> GetAllUserViewItem(int viewCod, string userId)
        {
            return _configUserViewItemService.GetAllUserViewItem(viewCod, userId);
        }
        
        public ConfigUserViewItem GetBy(string viewTipo, string userId)
        {
            return _configUserViewItemService.GetBy(viewTipo, userId);
        }

        public ConfigUserViewItem GetBy(int viewItemCod, string userId)
        {
            return _configUserViewItemService.GetBy(viewItemCod, userId);
        }                

        public void SetConfigUserViewItemOption(string textView, string styleTextView, string subTitle, string styleSubTitle, int viewItemCod, string userId)
        {
            var configUserViewItem = _configUserViewItemService.GetBy(viewItemCod, userId);
            if (configUserViewItem != null)
            {
                configUserViewItem.Change(textView, styleTextView, subTitle, styleSubTitle);          
                _configUserViewItemService.Update(configUserViewItem);
            }
        }  
      

        // Async Methods
        public async Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, string userId)
        {
            return await _configUserViewItemService.GetBasicViewItemAsync(viewTypeCod, userId);
        }
    }
}
