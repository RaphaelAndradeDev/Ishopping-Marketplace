using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentTextRepository : IRepositoryBaseT2<ContentText>, IContentRepositoryBaseT1<ContentText>, IContentRepositoryBaseT1Async<ContentText>
    {
        IEnumerable<ContentText> Search(string startsWith, int viewCod, string userId);
        ContentText GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<ContentText>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentText> GetByAsync(int viewCod, string term, string userId);
    }
}
