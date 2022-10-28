using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPricingOptionRepository : IRepositoryBaseT2<ComponentPricingOption>, IOptionRepositoryBaseT1<ComponentPricingOption>, IOptionRepositoryBaseT1Async<ComponentPricingOption>
    {        
    }
}
