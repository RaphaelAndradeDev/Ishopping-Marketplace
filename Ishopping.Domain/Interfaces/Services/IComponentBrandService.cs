using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentBrandService : IServiceBaseT2<ComponentBrand>, IComponentServiceBaseT2<ComponentBrand>, IComponentServiceBaseT2Async<ComponentBrand>
    {
        ComponentBrand GetByImageId(Guid imageId);
        Task<ComponentBrand> GetByImageIdAsync(Guid imageId);
    }
}
