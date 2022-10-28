using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentListService : ServiceBaseT2<ContentList>, IContentListService
    {
        private readonly IContentListRepository _contentListRepository;
        private readonly IContentListDapperRepository _contentListDapperRepository;

        public ContentListService(
            IContentListRepository contentListRepository,
            IContentListDapperRepository contentListDapperRepository)
            : base(contentListRepository)
        {
            _contentListRepository = contentListRepository;
            _contentListDapperRepository = contentListDapperRepository;
        }      

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber)
        {
            return _contentListDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentListDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentListDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId)
        {
            return _contentListRepository.GetAllByUserId(userId);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentListRepository.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentListRepository.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentList GetById(Guid id, string userId)
        {
            return _contentListRepository.GetById(id, userId);
        }

        public ContentList GetBy(int viewCod, int position, string userId)
        {
            return _contentListRepository.GetBy(viewCod, position, userId);
        }       

        public void DeleteAll(string userId)
        {
            _contentListRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentListDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentListDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentListDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId)
        {
            return await _contentListRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentListRepository.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentListRepository.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentList> GetByIdAsync(Guid id, string userId)
        {
            return await _contentListRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentList> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentListRepository.GetByAsync(viewCod, position, userId);
        }
    }
}
