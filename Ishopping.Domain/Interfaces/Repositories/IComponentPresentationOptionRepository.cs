using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPresentationOptionRepository : IRepositoryBaseT2<ComponentPresentationOption>, IOptionRepositoryBaseT1<ComponentPresentationOption>, IOptionRepositoryBaseT1Async<ComponentPresentationOption>
    {        
    }
}
