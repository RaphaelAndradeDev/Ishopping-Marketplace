using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentIconAppService : AppServiceBaseT2<ContentIcon>, IContentIconAppService
    {
        private readonly IContentIconService _contentIconService;

        public ContentIconAppService(IContentIconService contentIconService)
            :base(contentIconService)
        {
            _contentIconService = contentIconService;
        }

        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            return _contentIconService.Search(startsWith, viewCod, userId);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber)
        {
            return _contentIconService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentIconService.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentIconService.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId)
        {
            return _contentIconService.GetAllByUserId(userId);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentIconService.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentIconService.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentIcon GetById(Guid id, string userId)
        {
            return _contentIconService.GetById(id, userId);
        }

        public ContentIcon GetBy(int viewCod, int position, string userId)
        {
            return _contentIconService.GetBy(viewCod, position, userId);
        }

        public ContentIcon GetBy(int viewCod, string term, string userId)
        {
            return _contentIconService.GetBy(viewCod, term, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await _contentIconService.SearchAsync(startsWith, viewCod, userId);
        }
                
        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentIconService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentIconService.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentIconService.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId)
        {
            return await _contentIconService.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentIconService.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentIconService.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentIcon> GetByIdAsync(Guid id, string userId)
        {
            return await _contentIconService.GetByIdAsync(id, userId);
        }

        public async Task<ContentIcon> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentIconService.GetByAsync(viewCod, position, userId);
        }

        public async Task<ContentIcon> GetByAsync(int viewCod, string term, string userId)
        {
            return await _contentIconService.GetByAsync(viewCod, term, userId);
        }

        // Others Methods
        public async Task<object> GetObjetoAsync(int viewCod, int position, string userId)
        {
            var obj = await _contentIconService.GetByAsync(viewCod, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, icon = obj.Icon };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(int viewCod, string search, string userId)
        {
            var obj = await _contentIconService.GetByAsync(viewCod, search, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, icon = obj.Icon };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string icon)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();
            var contentIcon = await _contentIconService.GetByAsync(viewCod, position, userId);

            if (contentIcon != null)
            {                
                contentIcon.Change(viewCod, position, icon);
                json.Id = contentIcon.Id.ToString();
                return json;
            }
            else
            {
                contentIcon = new ContentIcon(userId, siteNumber, viewCod, position, icon);
                _contentIconService.Add(contentIcon);
                json.Id = contentIcon.Id.ToString();
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var icon = await _contentIconService.GetByIdAsync(_id, userId);

            if (icon != null)
            {              
                _contentIconService.Remove(icon);                             
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(icon.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _contentIconService.DeleteAll(userId);
        }        
    
    }
}
