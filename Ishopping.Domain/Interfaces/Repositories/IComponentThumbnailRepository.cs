using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentThumbnailRepository : IRepositoryBaseT2<ComponentThumbnail>, IComponentRepositoryBaseT2<ComponentThumbnail>, IComponentRepositoryBaseT2Async<ComponentThumbnail>
    {
        ComponentThumbnail GetByImageId(Guid imageId);
        Task<ComponentThumbnail> GetByImageIdAsync(Guid imageId);
    }
}
