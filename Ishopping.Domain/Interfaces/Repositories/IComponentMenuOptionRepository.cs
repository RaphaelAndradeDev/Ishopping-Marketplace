using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentMenuOptionRepository : IRepositoryBaseT2<ComponentMenuOption>, IOptionRepositoryBaseT1<ComponentMenuOption>, IOptionRepositoryBaseT1Async<ComponentMenuOption>
    {        
    }
}
