using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentVideoService : ServiceBaseT2<ContentVideo>, IContentVideoService
    {
        private readonly IContentVideoRepository _contentVideoRepository;
        private readonly IContentVideoDapperRepository _contentVideoDapperRepository;

        public ContentVideoService(
            IContentVideoRepository contentVideoRepository,
            IContentVideoDapperRepository contentVideoDapperRepository)
            : base(contentVideoRepository)
        {
            _contentVideoRepository = contentVideoRepository;
            _contentVideoDapperRepository = contentVideoDapperRepository;
        }        

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber)
        {
            return _contentVideoDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentVideoDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentVideoDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId)
        {
            return _contentVideoRepository.GetAllByUserId(userId);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentVideoRepository.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentVideoRepository.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentVideo GetById(Guid id, string userId)
        {
            return _contentVideoRepository.GetById(id, userId);
        }

        public ContentVideo GetBy(int viewCod, int position, string userId)
        {
            return _contentVideoRepository.GetBy(viewCod, position, userId);
        }              

        public void DeleteAll(string userId)
        {
            _contentVideoRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentVideoDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentVideoDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentVideoDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId)
        {
            return await _contentVideoRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentVideoRepository.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentVideoRepository.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentVideo> GetByIdAsync(Guid id, string userId)
        {
            return await _contentVideoRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentVideo> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentVideoRepository.GetByAsync(viewCod, position, userId);
        }
    }
}
