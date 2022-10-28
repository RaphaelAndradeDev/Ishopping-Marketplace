using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentFeaturesOptionRepository : IRepositoryBaseT2<ComponentFeaturesOption>, IOptionRepositoryBaseT1<ComponentFeaturesOption>, IOptionRepositoryBaseT1Async<ComponentFeaturesOption>
    {        
    }
}
