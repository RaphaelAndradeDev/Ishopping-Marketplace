using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentTeamSocialNetworkRepository : IRepositoryBaseT2<ComponentTeamSocialNetwork>
    {
        ComponentTeamSocialNetwork GetById(Guid id, string userId);
        Task<ComponentTeamSocialNetwork> GetByIdAsync(Guid id, string userId);
        void DeleteAll(Guid componentTeamId);
    }
}
