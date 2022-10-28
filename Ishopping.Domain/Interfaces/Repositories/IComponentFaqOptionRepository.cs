using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentFaqOptionRepository : IRepositoryBaseT2<ComponentFaqOption>, IOptionRepositoryBaseT1<ComponentFaqOption>, IOptionRepositoryBaseT1Async<ComponentFaqOption>
    {        
    }
}
