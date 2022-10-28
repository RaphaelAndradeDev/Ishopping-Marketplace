using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentListOptionService : IServiceBaseT2<ContentListOption>, IOptionServiceBaseT1<ContentListOption>, IOptionServiceBaseT1Async<ContentListOption>
    {
        ContentListOption Put(string lista, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ContentListOption> PutAsync(string lista, string userId);
    }
}
