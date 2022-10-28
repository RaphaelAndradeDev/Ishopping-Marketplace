using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPresentationRepository : IRepositoryBaseT2<ComponentPresentation>, IComponentRepositoryBaseT1<ComponentPresentation>, IComponentRepositoryBaseT1Async<ComponentPresentation>
    {
        ComponentPresentation GetByImageId(Guid imageId);
        Task<ComponentPresentation> GetByImageIdAsync(Guid imageId);
    }
}
