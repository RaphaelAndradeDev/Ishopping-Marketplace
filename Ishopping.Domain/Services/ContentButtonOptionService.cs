using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentButtonOptionService : ServiceBaseT2<ContentButtonOption>, IContentButtonOptionService
    {
        private readonly IContentButtonOptionRepository _contentButtonOptionRepository;

        public ContentButtonOptionService(IContentButtonOptionRepository contentButtonOptionRepository)
            : base(contentButtonOptionRepository)
        {
            _contentButtonOptionRepository = contentButtonOptionRepository;
        }

        public IEnumerable<ContentButtonOption> GetAllByUserId(string userId)
        {
            return _contentButtonOptionRepository.GetAllByUserId(userId);
        }

        public ContentButtonOption GetById(Guid id, string userId)
        {
            return _contentButtonOptionRepository.GetById(id, userId);
        }

        public ContentButtonOption GetDefault(string userId)
        {
            return _contentButtonOptionRepository.GetDefault(userId);
        }

        public ContentButtonOption Put(string textButton, string userId)
        {
            var buttonOption = _contentButtonOptionRepository.GetDefault(userId);

            bool alterStyle = textButton != buttonOption.TextBtn;
            if (alterStyle)
            {
                return new ContentButtonOption(userId, false, textButton);               
            }
            else
            {
                return buttonOption;   
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var button = GetAllByUserId(userId);

            foreach (var item in button)
            {
                item.Change(
                    item.Default,              
                    IsStyle.Rename(item.TextBtn, name, replace)
                    );
            }
            _contentButtonOptionRepository.Update(button);
        }

        public void StyleRemove(string userId, string name)
        {
            var button = GetAllByUserId(userId);

            foreach (var item in button)
            {
                item.Change(
                    item.Default,              
                    IsStyle.Remove(item.TextBtn, name)
                    );
            }
            _contentButtonOptionRepository.Update(button);
        }


        // Async Methods       
        public async Task<IEnumerable<ContentButtonOption>> GetAllByUserIdAsync(string userId)
        {
            return await _contentButtonOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ContentButtonOption> GetByIdAsync(Guid id)
        {
            return await _contentButtonOptionRepository.GetByIdAsync(id);
        }

        public async Task<ContentButtonOption> GetByIdAsync(Guid id, string userId)
        {
            return await _contentButtonOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentButtonOption> GetDefaultAsync(string userId)
        {
            return await _contentButtonOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ContentButtonOption> PutAsync(string textButton, string userId)
        {
            var buttonOption = await _contentButtonOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = textButton != buttonOption.TextBtn;
            if (alterStyle)
            {
                return new ContentButtonOption(userId, false, textButton);
            }
            else
            {
                return buttonOption;
            }
        }
    }
}
