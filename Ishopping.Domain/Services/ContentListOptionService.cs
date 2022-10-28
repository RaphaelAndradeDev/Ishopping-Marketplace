using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentListOptionService : ServiceBaseT2<ContentListOption>, IContentListOptionService
    {
        private readonly IContentListOptionRepository _contentListOptionRepository;

        public ContentListOptionService(IContentListOptionRepository contentListOptionRepository)
            : base(contentListOptionRepository)
        {
            _contentListOptionRepository = contentListOptionRepository;
        }

        public IEnumerable<ContentListOption> GetAllByUserId(string userId)
        {
            return _contentListOptionRepository.GetAllByUserId(userId);
        }

        public ContentListOption GetById(Guid id, string userId)
        {
            return _contentListOptionRepository.GetById(id, userId);
        }

        public ContentListOption GetDefault(string userId)
        {
            return _contentListOptionRepository.GetDefault(userId);
        }

        public ContentListOption Put(string lista, string userId)
        {
            var listOption = _contentListOptionRepository.GetDefault(userId);

            bool alterStyle = lista != listOption.Lista;
            if (alterStyle)
            {
                return new ContentListOption(userId, false, lista);                
            }
            else
            {
                return listOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var list = GetAllByUserId(userId);

            foreach (var item in list)
            {
                item.Change(
                    item.Default,              
                    IsStyle.Rename(item.Lista, name, replace)
                    );
            }
            _contentListOptionRepository.Update(list);
        }

        public void StyleRemove(string userId, string name)
        {
            var list = GetAllByUserId(userId);

            foreach (var item in list)
            {
                item.Change(
                    item.Default,               
                    IsStyle.Remove(item.Lista, name)
                    );
            }
            _contentListOptionRepository.Update(list);
        }


        // Async Methods       
        public async Task<IEnumerable<ContentListOption>> GetAllByUserIdAsync(string userId)
        {
            return await _contentListOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ContentListOption> GetByIdAsync(Guid id)
        {
            return await _contentListOptionRepository.GetByIdAsync(id);
        }

        public async Task<ContentListOption> GetByIdAsync(Guid id, string userId)
        {
            return await _contentListOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentListOption> GetDefaultAsync(string userId)
        {
            return await _contentListOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ContentListOption> PutAsync(string lista, string userId)
        {
            var listOption = await _contentListOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = lista != listOption.Lista;
            if (alterStyle)
            {
                return new ContentListOption(userId, false, lista);
            }
            else
            {
                return listOption;
            }
        }
    }
}
