using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentSummaryService : IServiceBaseT2<ComponentSummary>, IComponentServiceBaseT1<ComponentSummary>, IComponentServiceBaseT1Async<ComponentSummary>
    {
    }
}
