using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentTeamRepository : IRepositoryBaseT2<ComponentTeam>, IComponentRepositoryBaseT2<ComponentTeam>, IComponentRepositoryBaseT2Async<ComponentTeam>
    {
        ComponentTeam GetByImageId(Guid imageId);
        Task<ComponentTeam> GetByImageIdAsync(Guid imageId);
    }
}
