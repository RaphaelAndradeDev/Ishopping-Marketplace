using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentButtonOptionAppService : AppServiceBaseT2<ContentButtonOption>, IContentButtonOptionAppService
    {
        private readonly IContentButtonOptionService _contentButtonOptionService;

        public ContentButtonOptionAppService(IContentButtonOptionService contentButtonOptionService)
            :base(contentButtonOptionService)
        {
            _contentButtonOptionService = contentButtonOptionService;
        }

        public IEnumerable<ContentButtonOption> GetAllByUserId(string userId)
        {
            return _contentButtonOptionService.GetAllByUserId(userId);
        }

        public ContentButtonOption GetById(Guid id, string userId)
        {
            return _contentButtonOptionService.GetById(id, userId);
        }

        public ContentButtonOption GetDefault(string userId)
        {
            return _contentButtonOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentButtonOption>> GetAllByUserIdAsync(string userId)
        {
            return await _contentButtonOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ContentButtonOption> GetByIdAsync(Guid id)
        {
            return await _contentButtonOptionService.GetByIdAsync(id);
        }

        public async Task<ContentButtonOption> GetByIdAsync(Guid id, string userId)
        {
            return await _contentButtonOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ContentButtonOption> GetDefaultAsync(string userId)
        {
            return await _contentButtonOptionService.GetDefaultAsync(userId);
        }


        // Others Methods
        public async Task<JsonResponse> AppUpdateAsync(string textButton, string userId)
        {
            JsonResponse json = new JsonResponse();

            var buttonOption = await _contentButtonOptionService.GetDefaultAsync(userId);
            if (buttonOption != null)
            {
                buttonOption.Change(buttonOption.Default, textButton);         
                _contentButtonOptionService.Update(buttonOption);
            }

            return json;
        }
    }
}
