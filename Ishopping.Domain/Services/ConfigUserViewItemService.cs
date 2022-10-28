using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ConfigUserViewItemService : ServiceBaseT2<ConfigUserViewItem>, IConfigUserViewItemService
    {
        private readonly IConfigUserViewItemRepository _configUserViewItemRepository;
        private readonly IConfigUserViewItemDapperRepository _configUserViewItemDapperRepository;

        public ConfigUserViewItemService(
            IConfigUserViewItemRepository configUserViewItemRepository,
            IConfigUserViewItemDapperRepository configUserViewItemDapperRepository)
            : base(configUserViewItemRepository)
        {
            _configUserViewItemRepository = configUserViewItemRepository;
            _configUserViewItemDapperRepository = configUserViewItemDapperRepository;
        }

        public IEnumerable<ConfigUserViewItem> GetAllBySiteNumber(int siteNumber)
        {
            return _configUserViewItemDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public bool ExistItem(string viewTipo, string userId)
        {
            return _configUserViewItemRepository.ExistItem(viewTipo, userId);
        }
        
        public IEnumerable<ConfigUserViewItem> GetAllBy(int viewCod, string userId)
        {
            return _configUserViewItemRepository.GetAllBy(viewCod, userId);
        }
        
        public IEnumerable<GroupViewItem> GetAllUserViewItem(int viewCod, string userId)
        {
            return _configUserViewItemRepository.GetAllUserViewItem(viewCod, userId);
        }
        
        public ConfigUserViewItem GetBy(string viewTipo, string userId)
        {
            return _configUserViewItemRepository.GetBy(viewTipo, userId);
        }

        public ConfigUserViewItem GetBy(int viewItemCod, string userId)
        {
            return _configUserViewItemRepository.GetBy(viewItemCod, userId);
        }

        public ConfigUserViewItem GetBy(Guid id, string userId)
        {
            return _configUserViewItemRepository.GetBy(id, userId);
        }

        public IEnumerable<int> GetAllAdminViewItemCod(string userId)
        {
            return _configUserViewItemRepository.GetAllAdminViewItemCod(userId);
        }             

        public void StyleReplace(string userId, string name, string replace)
        {
            var userViewItem = _configUserViewItemRepository.GetAllByUserId(userId);

            foreach (var item in userViewItem)
            {
                item.StyleChange(                  
                    IsStyle.Rename(item.StTextView, name, replace),
                    IsStyle.Rename(item.StSubTitle, name, replace)
                    );
            }
            _configUserViewItemRepository.Update(userViewItem);
        }

        public void StyleRemove(string userId, string name)
        {
            var userViewItem = _configUserViewItemRepository.GetAllByUserId(userId);

            foreach (var item in userViewItem)
            {
                item.StyleChange(              
                    IsStyle.Remove(item.StTextView, name),
                    IsStyle.Remove(item.StSubTitle, name)
                    );
            }
            _configUserViewItemRepository.Update(userViewItem);
        }


        // Async Methods
        public async Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, string userId)
        {
            return await _configUserViewItemDapperRepository.GetBasicViewItemAsync(viewTypeCod, userId);
        }

        public async Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, int siteNumber)
        {
            return await _configUserViewItemDapperRepository.GetBasicViewItemAsync(viewTypeCod, siteNumber);
        }

        public async Task<IEnumerable<BasicUserViewItem>> GetAllBasicViewItemAsync(int[] viewTypeCod, int siteNumber)
        {
            return await _configUserViewItemDapperRepository.GetAllBasicViewItemAsync(viewTypeCod, siteNumber);
        }
    }
}
