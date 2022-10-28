using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentButtonService : ServiceBaseT2<ContentButton>, IContentButtonService
    {
        private readonly IContentButtonRepository _contentButtonRepository;
        private readonly IContentButtonDapperRepository _contentButtonDapperRepository;

        public ContentButtonService(
            IContentButtonRepository contentButtonRepository,
            IContentButtonDapperRepository contentButtonDapperRepository)
            : base(contentButtonRepository)
        {
            _contentButtonRepository = contentButtonRepository;
            _contentButtonDapperRepository = contentButtonDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            return _contentButtonRepository.Search(startsWith, viewCod, userId);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber)
        {
            return _contentButtonDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentButtonDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentButtonDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId)
        {
            return _contentButtonRepository.GetAllByUserId(userId);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentButtonRepository.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentButtonRepository.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentButton GetById(Guid id, string userId)
        {
            return _contentButtonRepository.GetById(id, userId);
        }

        public ContentButton GetBy(int viewCod, int position, string userId)
        {
            return _contentButtonRepository.GetBy(viewCod, position, userId);
        }

        public ContentButton GetBy(int viewCod, string term, string userId)
        {
            return _contentButtonRepository.GetBy(viewCod, term, userId);
        }

        public void DeleteAll(string userId)
        {
            _contentButtonRepository.DeleteAll(userId);
        }


        // Async Methods

        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await _contentButtonRepository.SearchAsync(startsWith, viewCod, userId);
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentButtonDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentButtonDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentButtonDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId)
        {
            return await _contentButtonRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentButtonRepository.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentButtonRepository.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentButton> GetByIdAsync(Guid id, string userId)
        {
            return await _contentButtonRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentButton> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentButtonRepository.GetByAsync(viewCod, position, userId);
        }
        
        public async Task<ContentButton> GetByAsync(int viewCod, string term, string userId)
        {
            return await _contentButtonRepository.GetByAsync(viewCod, term, userId);
        }
    }
}
