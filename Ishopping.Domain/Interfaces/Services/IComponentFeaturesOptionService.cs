using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentFeaturesOptionService : IServiceBaseT2<ComponentFeaturesOption>, IOptionServiceBaseT1<ComponentFeaturesOption>, IOptionServiceBaseT1Async<ComponentFeaturesOption>
    {
        ComponentFeaturesOption Put(string title, string count, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentFeaturesOption> PutAsync(string title, string count, string description, string userId);
    }
}
