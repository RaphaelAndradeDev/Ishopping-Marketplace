using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentServiceOptionService : IServiceBaseT2<ComponentServiceOption>, IOptionServiceBaseT1<ComponentServiceOption>, IOptionServiceBaseT1Async<ComponentServiceOption>
    {
        ComponentServiceOption Put(string title, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentServiceOption> PutAsync(string title, string description, string userId);
    }
}
