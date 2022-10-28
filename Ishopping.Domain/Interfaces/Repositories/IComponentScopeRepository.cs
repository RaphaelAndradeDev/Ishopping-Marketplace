using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentScopeRepository : IRepositoryBaseT2<ComponentScope>, IComponentRepositoryBaseT1<ComponentScope>, IComponentRepositoryBaseT1Async<ComponentScope>
    {
    }
}
