using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentClientService : IServiceBaseT2<ComponentClient>, IComponentServiceBaseT2<ComponentClient>, IComponentServiceBaseT2Async<ComponentClient>
    {
        ComponentClient GetByImageId(Guid imageId);
        Task<ComponentClient> GetByImageIdAsync(Guid imageId);
    }
}
