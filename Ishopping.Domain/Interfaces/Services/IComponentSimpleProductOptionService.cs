using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentSimpleProductOptionService : IServiceBaseT2<ComponentSimpleProductOption>, IOptionServiceBaseT1<ComponentSimpleProductOption>, IOptionServiceBaseT1Async<ComponentSimpleProductOption>
    {
        ComponentSimpleProductOption Put(string name, string category, string brand, string model, string description, string price, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentSimpleProductOption> PutAsync(string name, string category, string brand, string model, string description, string price, string userId);
    }
}
