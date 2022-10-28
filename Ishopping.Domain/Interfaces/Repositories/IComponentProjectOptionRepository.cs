using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentProjectOptionRepository : IRepositoryBaseT2<ComponentProjectOption>, IOptionRepositoryBaseT1<ComponentProjectOption>, IOptionRepositoryBaseT1Async<ComponentProjectOption>
    {        
    }
}
