using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentListOptionAppService : AppServiceBaseT2<ContentListOption>, IContentListOptionAppService
    {
        private readonly IContentListOptionService _contentListOptionService;

        public ContentListOptionAppService(IContentListOptionService contentListOptionService)
            :base(contentListOptionService)
        {
            _contentListOptionService = contentListOptionService;
        }

        public IEnumerable<ContentListOption> GetAllByUserId(string userId)
        {
            return _contentListOptionService.GetAllByUserId(userId);
        }

        public ContentListOption GetById(Guid id, string userId)
        {
            return _contentListOptionService.GetById(id, userId);
        }

        public ContentListOption GetDefault(string userId)
        {
            return _contentListOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentListOption>> GetAllByUserIdAsync(string userId)
        {
            return await _contentListOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ContentListOption> GetByIdAsync(Guid id)
        {
            return await _contentListOptionService.GetByIdAsync(id);
        }

        public async Task<ContentListOption> GetByIdAsync(Guid id, string userId)
        {
            return await _contentListOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ContentListOption> GetDefaultAsync(string userId)
        {
            return await _contentListOptionService.GetDefaultAsync(userId);
        }


        // Others Methods
        public async Task<JsonResponse> AppUpdateAsync(string lista, string userId)
        {
            JsonResponse json = new JsonResponse();

            var listOption = await _contentListOptionService.GetDefaultAsync(userId);
            if (listOption != null)
            {
                listOption.Change(listOption.Default, lista);
                _contentListOptionService.Update(listOption);
            }

            return json;
        }
    }
}
