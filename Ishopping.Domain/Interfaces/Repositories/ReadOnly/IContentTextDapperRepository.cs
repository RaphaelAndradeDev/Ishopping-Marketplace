using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IContentTextDapperRepository : IContentDapperRepositoryBaseT1<ContentText>
    {
        Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition);
        Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition, int viewCod);
    }
}
