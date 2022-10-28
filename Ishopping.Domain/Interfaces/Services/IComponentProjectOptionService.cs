using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentProjectOptionService : IServiceBaseT2<ComponentProjectOption>, IOptionServiceBaseT1<ComponentProjectOption>, IOptionServiceBaseT1Async<ComponentProjectOption>
    {
        ComponentProjectOption Put(string name, string title, string client, string description, string category, string team, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentProjectOption> PutAsync(string name, string title, string client, string description, string category, string team, string userId);
    }
}
