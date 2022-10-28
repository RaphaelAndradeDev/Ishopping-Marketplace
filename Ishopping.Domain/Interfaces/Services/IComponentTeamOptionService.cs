using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentTeamOptionService : IServiceBaseT2<ComponentTeamOption>, IOptionServiceBaseT1<ComponentTeamOption>, IOptionServiceBaseT1Async<ComponentTeamOption>
    {
        ComponentTeamOption Put(string name, string functio, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentTeamOption> PutAsync(string name, string functio, string description, string userId);
    }
}
