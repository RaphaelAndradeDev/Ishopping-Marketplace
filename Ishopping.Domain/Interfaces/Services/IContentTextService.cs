using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentTextService : IServiceBaseT2<ContentText>, IContentServiceBaseT1<ContentText>, IContentServiceBaseT1Async<ContentText>
    {
        IEnumerable<ContentText> Search(string startsWith, int viewCod, string userId);
        ContentText GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<ContentText>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentText> GetByAsync(int viewCod, string term, string userId);
        Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition);
        Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition, int viewCod);
    }
}
