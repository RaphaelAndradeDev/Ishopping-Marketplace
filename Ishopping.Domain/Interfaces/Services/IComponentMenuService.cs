using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentMenuService : IServiceBaseT2<ComponentMenu>, IComponentServiceBaseT2<ComponentMenu>, IComponentServiceBaseT2Async<ComponentMenu>
    {
        ComponentMenu GetByImageId(Guid imageId);
        Task<ComponentMenu> GetByImageIdAsync(Guid imageId);
    }
}
