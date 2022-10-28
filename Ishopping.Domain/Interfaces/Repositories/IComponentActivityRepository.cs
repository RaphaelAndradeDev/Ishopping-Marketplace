using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentActivityRepository : IRepositoryBaseT2<ComponentActivity>, IComponentRepositoryBaseT1<ComponentActivity>, IComponentRepositoryBaseT1Async<ComponentActivity>
    {
    }
}
