using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentTeamService : ServiceBaseT2<ComponentTeam>, IComponentTeamService
    {
        private readonly IComponentTeamRepository _componentTeamRepository;
        private readonly IComponentTeamDapperRepository _componentTeamDapperRepository;

        public ComponentTeamService(
            IComponentTeamRepository componentTeamRepository,
            IComponentTeamDapperRepository componentTeamDapperRepository)
            : base(componentTeamRepository)
        {
            _componentTeamRepository = componentTeamRepository;
            _componentTeamDapperRepository = componentTeamDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentTeamRepository.Search(startsWith, userId);
        }

        public ComponentTeam GetByImageId(Guid imageId)
        {
            return _componentTeamRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentTeam> GetAllBySiteNumber(int siteNumber)
        {
            return _componentTeamRepository.GetAllBySiteNumber(siteNumber);
        }        

        public ComponentTeam GetBySiteNumber(int siteNumber)
        {
            return _componentTeamRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentTeam> GetAllByUserId(string userId)
        {
            return _componentTeamRepository.GetAllByUserId(userId);
        }

        public ComponentTeam GetById(Guid id, string userId)
        {
            return _componentTeamRepository.GetById(id, userId);
        }

        public ComponentTeam GetByTerm(string term, string userId)
        {
            return _componentTeamRepository.GetByTerm(term, userId);
        }       

        public void DeleteAll(string userId)
        {
            _componentTeamRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentTeamRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentTeam> GetByImageIdAsync(Guid imageId)
        {
            return await _componentTeamRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentTeam> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentTeamRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentTeamRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllByUserIdAsync(string userId)
        {
            return await _componentTeamRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentTeam> GetByIdAsync(Guid id, string userId)
        {
            return await _componentTeamRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentTeam> GetByTermAsync(string term, string userId)
        {
            return await _componentTeamRepository.GetByTermAsync(term, userId);
        }  

    }
}
