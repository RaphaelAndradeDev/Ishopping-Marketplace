using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentThumbnailService : IServiceBaseT2<ComponentThumbnail>, IComponentServiceBaseT2<ComponentThumbnail>, IComponentServiceBaseT2Async<ComponentThumbnail>
    {
        ComponentThumbnail GetByImageId(Guid imageId);
        Task<ComponentThumbnail> GetByImageIdAsync(Guid imageId);
    }
}
