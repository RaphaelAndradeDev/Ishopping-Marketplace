using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPostOptionRepository : IRepositoryBaseT2<ComponentPostOption>, IOptionRepositoryBaseT1<ComponentPostOption>, IOptionRepositoryBaseT1Async<ComponentPostOption>
    {        
    }
}
