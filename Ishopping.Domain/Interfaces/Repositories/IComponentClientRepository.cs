using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentClientRepository : IRepositoryBaseT2<ComponentClient>, IComponentRepositoryBaseT2<ComponentClient>, IComponentRepositoryBaseT2Async<ComponentClient>
    {
        ComponentClient GetByImageId(Guid imageId);
        Task<ComponentClient> GetByImageIdAsync(Guid imageId);
    }
}
