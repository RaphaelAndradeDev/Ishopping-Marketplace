using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentScopeOptionService : IServiceBaseT2<ComponentScopeOption>, IOptionServiceBaseT1<ComponentScopeOption>, IOptionServiceBaseT1Async<ComponentScopeOption>
    {
        ComponentScopeOption Put(string title, string category, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentScopeOption> PutAsync(string title, string category, string description, string userId);
    }
}
