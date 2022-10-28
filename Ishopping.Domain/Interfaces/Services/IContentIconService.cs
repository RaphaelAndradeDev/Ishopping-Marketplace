using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentIconService : IServiceBaseT2<ContentIcon>, IContentServiceBaseT1<ContentIcon>, IContentServiceBaseT1Async<ContentIcon>
    {
        IEnumerable<string> Search(string startsWith, int viewCod, string userId);
        ContentIcon GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentIcon> GetByAsync(int viewCod, string term, string userId);
    }
}
