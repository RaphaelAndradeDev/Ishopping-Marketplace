using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentBrandOptionService : IServiceBaseT2<ComponentBrandOption>, IOptionServiceBaseT1<ComponentBrandOption>, IOptionServiceBaseT1Async<ComponentBrandOption>
    {
        Task<ComponentBrandOption> PutAsync(string marca, string comment, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);
    }
}
