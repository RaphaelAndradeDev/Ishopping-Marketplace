using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentProjectService : IServiceBaseT2<ComponentProject>, IComponentServiceBaseT2<ComponentProject>, IComponentServiceBaseT2Async<ComponentProject>
    {
        ComponentProject GetByImageId(Guid imageId);
        void AddBy(ComponentProject componentProject);
        void UpdateBy(ComponentProject componentProject);

        // Async Methods
        Task<ComponentProject> GetByImageIdAsync(Guid imageId);
    }
}
