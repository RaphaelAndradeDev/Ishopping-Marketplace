using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPresentationService : IServiceBaseT2<ComponentPresentation>, IComponentServiceBaseT1<ComponentPresentation>, IComponentServiceBaseT1Async<ComponentPresentation>
    {
        ComponentPresentation GetByImageId(Guid imageId);
        Task<ComponentPresentation> GetByImageIdAsync(Guid imageId);
    }
}
