using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentButtonRepository : IRepositoryBaseT2<ContentButton>, IContentRepositoryBaseT1<ContentButton>, IContentRepositoryBaseT1Async<ContentButton>
    {
        IEnumerable<string> Search(string startsWith, int viewCod, string userId);
        ContentButton GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentButton> GetByAsync(int viewCod, string term, string userId);
    }
}
