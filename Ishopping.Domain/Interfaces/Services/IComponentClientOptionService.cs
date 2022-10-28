using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentClientOptionService : IServiceBaseT2<ComponentClientOption>, IOptionServiceBaseT1<ComponentClientOption>, IOptionServiceBaseT1Async<ComponentClientOption>
    {
        ComponentClientOption Put(string name, string functio, string comment, string projects, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentClientOption> PutAsync(string name, string functio, string comment, string projects, string userId);
    }
}
