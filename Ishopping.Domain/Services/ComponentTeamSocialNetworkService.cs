using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class ComponentTeamSocialNetworkService : ServiceBaseT2<ComponentTeamSocialNetwork>, IComponentTeamSocialNetworkService
    {
        private readonly IComponentTeamSocialNetworkRepository _componentTeamSocialNetworkRepository;
        private readonly IAdminSocialNetWorkRepository _adminSocialNetWorkRepository;

        public ComponentTeamSocialNetworkService(
            IComponentTeamSocialNetworkRepository componentTeamSocialNetworkRepository,
            IAdminSocialNetWorkRepository adminSocialNetWorkRepository)
            : base(componentTeamSocialNetworkRepository)
        {
            _componentTeamSocialNetworkRepository = componentTeamSocialNetworkRepository;
            _adminSocialNetWorkRepository = adminSocialNetWorkRepository;
        }

        public ComponentTeamSocialNetwork GetById(Guid id, string userId)
        {
            return _componentTeamSocialNetworkRepository.GetById(id, userId);
        }

        public AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod)
        {
            return _adminSocialNetWorkRepository.GetBy(rede, templateCod);
        }

        public void DeleteAll(Guid componentTeamId)
        {
            _componentTeamSocialNetworkRepository.DeleteAll(componentTeamId);
        }


        // Async Methods
        public async Task<ComponentTeamSocialNetwork> GetByIdAsync(Guid id, string userId)
        {
            return await _componentTeamSocialNetworkRepository.GetByIdAsync(id, userId);
        }
    }
}
