using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPanelOptionRepository : IRepositoryBaseT2<ComponentPanelOption>, IOptionRepositoryBaseT1<ComponentPanelOption>, IOptionRepositoryBaseT1Async<ComponentPanelOption>
    {        
    }
}
