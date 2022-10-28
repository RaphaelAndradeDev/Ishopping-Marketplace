using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentTextService : ServiceBaseT2<ContentText>, IContentTextService
    {
        private readonly IContentTextRepository _contentTextRepository;
        private readonly IContentTextDapperRepository _contentTextDapperRepository;

        public ContentTextService(
            IContentTextRepository contentTextRepository,
            IContentTextDapperRepository contentTextDapperRepository)
            : base(contentTextRepository)
        {
            _contentTextRepository = contentTextRepository;
            _contentTextDapperRepository = contentTextDapperRepository;
        }

        public IEnumerable<ContentText> Search(string startsWith, int viewCod, string userId)
        {
            return _contentTextRepository.Search(startsWith, viewCod, userId);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber)
        {
            return _contentTextDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentTextDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentTextDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId)
        {
            return _contentTextRepository.GetAllByUserId(userId);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentTextRepository.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentTextRepository.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentText GetById(Guid id, string userId)
        {
            return _contentTextRepository.GetById(id, userId);
        }

        public ContentText GetBy(int viewCod, int position, string userId)
        {
            return _contentTextRepository.GetBy(viewCod, position, userId);
        }

        public ContentText GetBy(int viewCod, string term, string userId)
        {
            return _contentTextRepository.GetBy(viewCod, term, userId);
        }

        public void DeleteAll(string userId)
        {
            _contentTextRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentText>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await _contentTextRepository.SearchAsync(startsWith, viewCod, userId);
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentTextDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentTextDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentTextDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId)
        {
            return await _contentTextRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentTextRepository.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentTextRepository.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentText> GetByIdAsync(Guid id, string userId)
        {
            return await _contentTextRepository.GetByIdAsync(id, userId);
        }

        public async Task<ContentText> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentTextRepository.GetByAsync(viewCod, position, userId);
        }

        public async Task<ContentText> GetByAsync(int viewCod, string term, string userId)
        {
            return await _contentTextRepository.GetByAsync(viewCod, term, userId);
        }

        public async Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition)
        {
            return await _contentTextDapperRepository.GetAllBasicTextAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentTextDapperRepository.GetAllBasicTextAsync(siteNumber, maxPosition, viewCod);
        }
    }
}
