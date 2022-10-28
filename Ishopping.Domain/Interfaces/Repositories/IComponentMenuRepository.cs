using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentMenuRepository : IRepositoryBaseT2<ComponentMenu>, IComponentRepositoryBaseT2<ComponentMenu>, IComponentRepositoryBaseT2Async<ComponentMenu>
    {
        ComponentMenu GetByImageId(Guid imageId);
        Task<ComponentMenu> GetByImageIdAsync(Guid imageId);
    }
}
