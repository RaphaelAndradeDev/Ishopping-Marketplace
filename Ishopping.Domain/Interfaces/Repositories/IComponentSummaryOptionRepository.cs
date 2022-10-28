using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentSummaryOptionRepository : IRepositoryBaseT2<ComponentSummaryOption>, IOptionRepositoryBaseT1<ComponentSummaryOption>, IOptionRepositoryBaseT1Async<ComponentSummaryOption>
    {        
    }
}
