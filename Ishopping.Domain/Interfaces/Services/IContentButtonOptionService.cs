using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentButtonOptionService : IServiceBaseT2<ContentButtonOption>, IOptionServiceBaseT1<ContentButtonOption>, IOptionServiceBaseT1Async<ContentButtonOption>
    {
        ContentButtonOption Put(string textButton, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ContentButtonOption> PutAsync(string textButton, string userId);
    }
}
