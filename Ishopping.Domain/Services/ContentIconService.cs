using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentIconService : ServiceBaseT2<ContentIcon>, IContentIconService
    {
        private readonly IContentIconRepository _contentIconRepository;
        private readonly IContentIconDapperRepository _contentIconDapperRepository;

        public ContentIconService(
            IContentIconRepository contentIconRepository,
            IContentIconDapperRepository contentIconDapperRepository)
            : base(contentIconRepository)
        {
            _contentIconRepository = contentIconRepository;
            _contentIconDapperRepository = contentIconDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            return _contentIconRepository.Search(startsWith, viewCod, userId);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber)
        {
            return _contentIconDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentIconDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentIconDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId)
        {
            return _contentIconRepository.GetAllByUserId(userId);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentIconRepository.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentIconRepository.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentIcon GetById(Guid id, string userId)
        {
            return _contentIconRepository.GetById(id, userId);
        }

        public ContentIcon GetBy(int viewCod, int position, string userId)
        {
            return _contentIconRepository.GetBy(viewCod, position, userId);
        }

        public ContentIcon GetBy(int viewCod, string term, string userId)
        {
            return _contentIconRepository.GetBy(viewCod, term, userId);
        }

        public void DeleteAll(string userId)
        {
            _contentIconRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await _contentIconRepository.SearchAsync(startsWith, viewCod, userId);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentIconDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentIconDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentIconDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId)
        {
            return await _contentIconRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentIconRepository.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentIconRepository.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentIcon> GetByIdAsync(Guid id, string userId)
        {
            return await _contentIconRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentIcon> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentIconRepository.GetByAsync(viewCod, position, userId);
        }

        public async Task<ContentIcon> GetByAsync(int viewCod, string term, string userId)
        {
            return await _contentIconRepository.GetByAsync(viewCod, term, userId);
        }
    }
}
