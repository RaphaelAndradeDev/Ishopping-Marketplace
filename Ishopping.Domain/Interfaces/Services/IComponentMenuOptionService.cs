using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentMenuOptionService : IServiceBaseT2<ComponentMenuOption>, IOptionServiceBaseT1<ComponentMenuOption>, IOptionServiceBaseT1Async<ComponentMenuOption>
    {
        ComponentMenuOption Put(string title, string description, string price, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentMenuOption> PutAsync(string title, string description, string price, string userId);
    }
}
