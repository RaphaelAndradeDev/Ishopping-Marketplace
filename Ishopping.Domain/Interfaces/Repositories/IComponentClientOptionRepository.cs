using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentClientOptionRepository : IRepositoryBaseT2<ComponentClientOption>, IOptionRepositoryBaseT1<ComponentClientOption>, IOptionRepositoryBaseT1Async<ComponentClientOption>
    {        
    }
}
