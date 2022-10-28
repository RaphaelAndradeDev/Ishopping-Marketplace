using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentThumbnailService : ServiceBaseT2<ComponentThumbnail>, IComponentThumbnailService
    {
        private readonly IComponentThumbnailRepository _componentThumbnailRepository;
        private readonly IComponentThumbnailDapperRepository _componentThumbnailDapperRepository;

        public ComponentThumbnailService(
            IComponentThumbnailRepository componentThumbnailRepository,
            IComponentThumbnailDapperRepository componentThumbnailDapperRepository)
            : base(componentThumbnailRepository)
        {
            _componentThumbnailRepository = componentThumbnailRepository;
            _componentThumbnailDapperRepository = componentThumbnailDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentThumbnailRepository.Search(startsWith, userId);
        }

        public ComponentThumbnail GetByImageId(Guid imageId)
        {
            return _componentThumbnailRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentThumbnail> GetAllBySiteNumber(int siteNumber)
        {
            return _componentThumbnailDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentThumbnail GetBySiteNumber(int siteNumber)
        {
            return _componentThumbnailRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentThumbnail> GetAllByUserId(string userId)
        {
            return _componentThumbnailRepository.GetAllByUserId(userId);
        }

        public ComponentThumbnail GetById(Guid id, string userId)
        {
            return _componentThumbnailRepository.GetById(id, userId);
        }

        public ComponentThumbnail GetByTerm(string title, string userId)
        {
            return _componentThumbnailRepository.GetByTerm(title, userId);
        }

        public void DeleteAll(string userId)
        {
            _componentThumbnailRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentThumbnailRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentThumbnail> GetByImageIdAsync(Guid imageId)
        {
            return await _componentThumbnailRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentThumbnail> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentThumbnailRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentThumbnailDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllByUserIdAsync(string userId)
        {
            return await _componentThumbnailRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentThumbnail> GetByIdAsync(Guid id, string userId)
        {
            return await _componentThumbnailRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentThumbnail> GetByTermAsync(string term, string userId)
        {
            return await _componentThumbnailRepository.GetByTermAsync(term, userId);
        }  

    }
}
