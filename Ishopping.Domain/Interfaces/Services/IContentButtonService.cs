using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentButtonService : IServiceBaseT2<ContentButton>, IContentServiceBaseT1<ContentButton>, IContentServiceBaseT1Async<ContentButton>
    {
        IEnumerable<string> Search(string startsWith, int viewCod, string userId);
        ContentButton GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentButton> GetByAsync(int viewCod, string term, string userId);
    }
}
