using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentTextOptionService : IServiceBaseT2<ContentTextOption>, IOptionServiceBaseT1<ContentTextOption>, IOptionServiceBaseT1Async<ContentTextOption>
    {
        ContentTextOption Put(string text32, string text512, string text5120, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ContentTextOption> PutAsync(string text32, string text512, string text5120, string userId);
    }
}
