using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentListService : IServiceBaseT2<ContentList>, IContentServiceBaseT1<ContentList>, IContentServiceBaseT1Async<ContentList>
    {        
    }
}
