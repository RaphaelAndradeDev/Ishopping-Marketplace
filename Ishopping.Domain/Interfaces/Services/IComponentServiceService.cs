using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentServiceService : IServiceBaseT2<ComponentService>, IComponentServiceBaseT1<ComponentService>, IComponentServiceBaseT1Async<ComponentService>
    {
        ComponentService GetByImageId(Guid imageId);
        Task<ComponentService> GetByImageIdAsync(Guid imageId);
    }
}
