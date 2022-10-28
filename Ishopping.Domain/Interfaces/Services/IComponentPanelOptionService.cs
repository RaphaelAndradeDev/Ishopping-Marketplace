using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPanelOptionService : IServiceBaseT2<ComponentPanelOption>, IOptionServiceBaseT1<ComponentPanelOption>, IOptionServiceBaseT1Async<ComponentPanelOption>
    {
        ComponentPanelOption Put(string title, string text, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentPanelOption> PutAsync(string title, string text, string userId);
    }
}
