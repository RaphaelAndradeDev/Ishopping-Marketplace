using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentScopeOptionRepository : IRepositoryBaseT2<ComponentScopeOption>, IOptionRepositoryBaseT1<ComponentScopeOption>, IOptionRepositoryBaseT1Async<ComponentScopeOption>
    {        
    }
}
