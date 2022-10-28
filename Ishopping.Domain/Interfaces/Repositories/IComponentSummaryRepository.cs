using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentSummaryRepository : IRepositoryBaseT2<ComponentSummary>, IComponentRepositoryBaseT1<ComponentSummary>, IComponentRepositoryBaseT1Async<ComponentSummary>
    {
    }
}
