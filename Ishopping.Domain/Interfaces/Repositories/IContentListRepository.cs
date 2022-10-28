using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentListRepository : IRepositoryBaseT2<ContentList>, IContentRepositoryBaseT1<ContentList>, IContentRepositoryBaseT1Async<ContentList>
    {        
    }
}
