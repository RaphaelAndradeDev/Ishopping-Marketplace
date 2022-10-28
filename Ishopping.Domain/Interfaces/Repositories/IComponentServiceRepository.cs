using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentServiceRepository : IRepositoryBaseT2<ComponentService>, IComponentRepositoryBaseT1<ComponentService>, IComponentRepositoryBaseT1Async<ComponentService>
    {
        ComponentService GetByImageId(Guid imageId);
        Task<ComponentService> GetByImageIdAsync(Guid imageId);
    }
}
