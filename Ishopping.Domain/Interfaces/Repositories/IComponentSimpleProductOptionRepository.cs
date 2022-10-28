using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentSimpleProductOptionRepository : IRepositoryBaseT2<ComponentSimpleProductOption>, IOptionRepositoryBaseT1<ComponentSimpleProductOption>, IOptionRepositoryBaseT1Async<ComponentSimpleProductOption>
    {        
    }
}
