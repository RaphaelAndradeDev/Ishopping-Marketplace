using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentVideoAppService : AppServiceBaseT2<ContentVideo>, IContentVideoAppService
    {
        private readonly IContentVideoService _contentVideoService;

        public ContentVideoAppService(IContentVideoService contentVideoService)
            :base(contentVideoService)
        {
            _contentVideoService = contentVideoService;
        }       

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber)
        {
            return _contentVideoService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentVideoService.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentVideoService.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId)
        {
            return _contentVideoService.GetAllByUserId(userId);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentVideoService.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentVideoService.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentVideo GetById(Guid id, string userId)
        {
            return _contentVideoService.GetById(id, userId);
        }

        public ContentVideo GetBy(int viewCod, int position, string userId)
        {
            return _contentVideoService.GetBy(viewCod, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentVideoService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentVideoService.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentVideoService.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId)
        {
            return await _contentVideoService.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentVideoService.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentVideoService.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentVideo> GetByIdAsync(Guid id, string userId)
        {
            return await _contentVideoService.GetByIdAsync(id, userId);
        }

        public async Task<ContentVideo> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentVideoService.GetByAsync(viewCod, position, userId);
        }


        // Others Methods
        public async Task<object> GetObjetoAsync(int viewCod, int position, string userId)
        {
            var obj = await _contentVideoService.GetByAsync(viewCod, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, url = obj.Url };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string url)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();
            var contentVideo = await _contentVideoService.GetByAsync(viewCod, position, userId);

            if (contentVideo != null)
            {                
                contentVideo.Change(viewCod, position, url);
                json.Id = contentVideo.Id.ToString();
                return json;
            }
            else
            {
                contentVideo = new ContentVideo(userId, siteNumber, viewCod, position, url);
                _contentVideoService.Add(contentVideo);
                json.Id = contentVideo.Id.ToString();
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var video = await _contentVideoService.GetByIdAsync(_id, userId);

            if (video != null)
            {
                _contentVideoService.Remove(video);
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(video.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _contentVideoService.DeleteAll(userId);
        }
    }
}
