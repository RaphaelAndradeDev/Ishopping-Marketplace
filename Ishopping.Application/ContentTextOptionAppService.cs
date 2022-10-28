using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentTextOptionAppService : AppServiceBaseT2<ContentTextOption>, IContentTextOptionAppService
    {
        private readonly IContentTextOptionService _contentTextOptionService;

        public ContentTextOptionAppService(IContentTextOptionService contentTextOptionService)
            : base(contentTextOptionService)
        {
            _contentTextOptionService = contentTextOptionService;
        }

        public IEnumerable<ContentTextOption> GetAllByUserId(string userId)
        {
            return _contentTextOptionService.GetAllByUserId(userId);
        }

        public ContentTextOption GetById(Guid id, string userId)
        {
            return _contentTextOptionService.GetById(id, userId);
        }

        public ContentTextOption GetDefault(string userId)
        {
            return _contentTextOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentTextOption>> GetAllByUserIdAsync(string userId)
        {
            return await _contentTextOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ContentTextOption> GetByIdAsync(Guid id)
        {
            return await _contentTextOptionService.GetByIdAsync(id);
        }

        public async Task<ContentTextOption> GetByIdAsync(Guid id, string userId)
        {
            return await _contentTextOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ContentTextOption> GetDefaultAsync(string userId)
        {
            return await _contentTextOptionService.GetDefaultAsync(userId);
        }


        // Others Methods
        public async Task<JsonResponse> AppUpdateAsync(string text32, string text512, string text5120, string userId)
        {
            JsonResponse json = new JsonResponse();

            var textOption = await _contentTextOptionService.GetDefaultAsync(userId);
            if (textOption != null)
            {
                textOption.Change(textOption.Default, text32, text512, text5120);       
                _contentTextOptionService.Update(textOption);
            }

            return json;
        }        
        
    }
}
