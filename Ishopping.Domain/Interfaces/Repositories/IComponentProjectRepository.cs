using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentProjectRepository : IRepositoryBaseT2<ComponentProject>, IComponentRepositoryBaseT2<ComponentProject>, IComponentRepositoryBaseT2Async<ComponentProject>
    {
        ComponentProject GetByImageId(Guid imageId);
        void AddBy(ComponentProject componentProject);
        void UpdateBy(ComponentProject componentProject);

        // Async Methods
        Task<ComponentProject> GetByImageIdAsync(Guid imageId);
    }
}
