using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPresentationOptionService : IServiceBaseT2<ComponentPresentationOption>, IOptionServiceBaseT1<ComponentPresentationOption>, IOptionServiceBaseT1Async<ComponentPresentationOption>
    {
        ComponentPresentationOption Put(string title, string category, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentPresentationOption> PutAsync(string title, string category, string description, string userId);
    }
}
