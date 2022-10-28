using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentTextOptionService : ServiceBaseT2<ContentTextOption>, IContentTextOptionService
    {
        private readonly IContentTextOptionRepository _contentTextOptionRepository;

        public ContentTextOptionService(IContentTextOptionRepository contentTextOptionRepository)
            : base(contentTextOptionRepository)
        {
            _contentTextOptionRepository = contentTextOptionRepository;
        }

        public IEnumerable<ContentTextOption> GetAllByUserId(string userId)
        {
            return _contentTextOptionRepository.GetAllByUserId(userId);
        }

        public ContentTextOption GetById(Guid id, string userId)
        {
            return _contentTextOptionRepository.GetById(id, userId);
        }

        public ContentTextOption GetDefault(string userId)
        {
            return _contentTextOptionRepository.GetDefault(userId);
        }

        public ContentTextOption Put(string text32, string text512, string text5120, string userId)
        {
            var textOption = _contentTextOptionRepository.GetDefault(userId);

            bool alterStyle = text32 != textOption.Text32 || text512 != textOption.Text512 || text5120 != textOption.Text5120;
            if (alterStyle)
            {
                return new ContentTextOption(userId, false, text32, text512, text5120);                
            }
            else
            {
                return textOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var text = GetAllByUserId(userId);

            foreach (var item in text)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Text32, name, replace),
                    IsStyle.Rename(item.Text512, name, replace),
                    IsStyle.Rename(item.Text5120, name, replace)
                    );
            }
            _contentTextOptionRepository.Update(text);
        }

        public void StyleRemove(string userId, string name)
        {
            var text = GetAllByUserId(userId);

            foreach (var item in text)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Text32, name),
                    IsStyle.Remove(item.Text512, name),
                    IsStyle.Remove(item.Text5120, name)
                    );
            }
            _contentTextOptionRepository.Update(text);
        }


        // Async Methods       
        public async Task<IEnumerable<ContentTextOption>> GetAllByUserIdAsync(string userId)
        {
            return await _contentTextOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ContentTextOption> GetByIdAsync(Guid id)
        {
            return await _contentTextOptionRepository.GetByIdAsync(id);
        }

        public async Task<ContentTextOption> GetByIdAsync(Guid id, string userId)
        {
            return await _contentTextOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentTextOption> GetDefaultAsync(string userId)
        {
            return await _contentTextOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ContentTextOption> PutAsync(string text32, string text512, string text5120, string userId)
        {
            var textOption = await _contentTextOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = text32 != textOption.Text32 || text512 != textOption.Text512 || text5120 != textOption.Text5120;
            if (alterStyle)
            {
                return new ContentTextOption(userId, false, text32, text512, text5120);
            }
            else
            {
                return textOption;
            }
        }
    }
}
