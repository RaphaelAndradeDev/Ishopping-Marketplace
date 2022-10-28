using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentBrandOptionRepository : IRepositoryBaseT2<ComponentBrandOption>, IOptionRepositoryBaseT1<ComponentBrandOption>, IOptionRepositoryBaseT1Async<ComponentBrandOption>
    {        
    }
}
