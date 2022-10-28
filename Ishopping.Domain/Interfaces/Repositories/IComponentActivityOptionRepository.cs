using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentActivityOptionRepository : IRepositoryBaseT2<ComponentActivityOption>, IOptionRepositoryBaseT1<ComponentActivityOption>, IOptionRepositoryBaseT1Async<ComponentActivityOption>
    {
        void UpdateAll(IEnumerable<ComponentActivityOption> componentActivityOption);
    }
}
