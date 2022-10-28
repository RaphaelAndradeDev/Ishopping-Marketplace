using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentTeamService : IServiceBaseT2<ComponentTeam>, IComponentServiceBaseT2<ComponentTeam>, IComponentServiceBaseT2Async<ComponentTeam>
    {
        ComponentTeam GetByImageId(Guid imageId);
        Task<ComponentTeam> GetByImageIdAsync(Guid imageId);
    }
}
