using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentVideoService : IServiceBaseT2<ContentVideo>, IContentServiceBaseT1<ContentVideo>, IContentServiceBaseT1Async<ContentVideo>
    {
    }
}
