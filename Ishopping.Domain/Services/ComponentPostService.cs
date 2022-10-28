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
    public class ComponentPostService : ServiceBaseT2<ComponentPost>, IComponentPostService
    {
        private readonly IComponentPostRepository _componentPostRepository;
        private readonly IComponentPostDapperRepository _componentPostDapperRepository;

        public ComponentPostService(
            IComponentPostRepository componentPostRepository,
            IComponentPostDapperRepository componentPostDapperRepository)
            : base(componentPostRepository)
        {
            _componentPostRepository = componentPostRepository;
            _componentPostDapperRepository = componentPostDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentPostRepository.Search(startsWith, userId);
        }

        public ComponentPost GetByImageId(Guid imageId)
        {
            return _componentPostRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentPost> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPostRepository.GetAllBySiteNumber(siteNumber);
        }              

        public ComponentPost GetBySiteNumber(int siteNumber)
        {
            return _componentPostRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPost> GetOrderByDate(int siteNumber, int take)
        {
            return _componentPostRepository.GetOrderByDate(siteNumber, take);
        }

        public IEnumerable<ComponentPost> GetAllByUserId(string userId)
        {
            return _componentPostRepository.GetAllByUserId(userId);
        }

        public ComponentPost GetBy(Guid id)
        {
            return _componentPostRepository.GetBy(id);
        }

        public ComponentPost GetById(Guid id, string userId)
        {
            return _componentPostRepository.GetById(id, userId);
        }

        public ComponentPost GetByTerm(string term, string userId)
        {
            return _componentPostRepository.GetByTerm(term, userId);
        }               
        
        public void AddBy(ComponentPost componentPost)
        {
            _componentPostRepository.AddBy(componentPost);
        }
        
        public void UpdateBy(ComponentPost componentPost)
        {
            _componentPostRepository.UpdateBy(componentPost);
        }        

        public void DeleteAll(string userId)
        {
            _componentPostRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentPostRepository.SearchAsync(startsWith, userId);
        }

        public async Task<IEnumerable<string>> SearchAsync(string startsWith)
        {
            return await _componentPostRepository.SearchAsync(startsWith);
        }

        public async Task<ComponentPost> GetByImageIdAsync(Guid imageId)
        {
            return await _componentPostRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentPost> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPostRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPost>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPostDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPost>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPostRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPost> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPostRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPost> GetByTermAsync(string term, string userId)
        {
            return await _componentPostRepository.GetByTermAsync(term, userId);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term)
        {
            return await _componentPostRepository.GetAllByTermAsync(term);
        }

        public async Task<IEnumerable<string>> GetAllCategoryAsync()
        {
            return await _componentPostRepository.GetAllCategoryAsync();
        }


        // Async Methods for SinglePost
        public async Task<SinglePost> GetSinglePostByIdAsync(Guid id)
        {
            return await _componentPostDapperRepository.GetSinglePostByIdAsync(id);
        }

        // Async Methods for SimplePost
        public async Task<IEnumerable<SimplePost>> GetAllBySiteNumberAsync(int siteNumber, int take) 
        {
            return await _componentPostDapperRepository.GetAllBySiteNumberAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int take)
        {
            return await _componentPostDapperRepository.GetAllByLastDateAsync(take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int siteNumber, int take)
        {
            return await _componentPostDapperRepository.GetAllByLastDateAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(string category, int take)
        {
            return await _componentPostDapperRepository.GetAllByLastDateAsync(category, take);
        } 

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int take)
        {
            return await _componentPostDapperRepository.GetAllByCategoryAsync(category, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int siteNumber, int take)
        {
            return await _componentPostDapperRepository.GetAllByCategoryAsync(category, siteNumber, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int take)
        {
            return await _componentPostDapperRepository.GetAllByViewsAsync(take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int siteNumber, int take)
        {
            return await _componentPostDapperRepository.GetAllByViewsAsync(siteNumber, take);
        }
    }
}
