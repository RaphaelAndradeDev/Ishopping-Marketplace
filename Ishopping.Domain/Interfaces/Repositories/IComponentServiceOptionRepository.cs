using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentServiceOptionRepository : IRepositoryBaseT2<ComponentServiceOption>, IOptionRepositoryBaseT1<ComponentServiceOption>, IOptionRepositoryBaseT1Async<ComponentServiceOption>
    {        
    }
}
