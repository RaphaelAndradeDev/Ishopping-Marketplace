using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentBrandRepository : IRepositoryBaseT2<ComponentBrand>, IComponentRepositoryBaseT2<ComponentBrand>, IComponentRepositoryBaseT2Async<ComponentBrand>
    {
        ComponentBrand GetByImageId(Guid imageId);
        Task<ComponentBrand> GetByImageIdAsync(Guid imageId);
    }
}
