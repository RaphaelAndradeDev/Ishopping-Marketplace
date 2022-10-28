using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentExtraLinkOptionService : IServiceBaseT2<ComponentExtraLinkOption>, IOptionServiceBaseT1<ComponentExtraLinkOption>, IOptionServiceBaseT1Async<ComponentExtraLinkOption>
    {
        ComponentExtraLinkOption Put(string textLink, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentExtraLinkOption> PutAsync(string textLink, string description, string userId);
    }
}
