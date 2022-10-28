using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPostOptionService : IServiceBaseT2<ComponentPostOption>, IOptionServiceBaseT1<ComponentPostOption>, IOptionServiceBaseT1Async<ComponentPostOption>
    {
        ComponentPostOption Put(string autor, string categoria, string titulo, string subTitulo, string paragrafo, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentPostOption> PutAsync(string autor, string categoria, string titulo, string subTitulo, string paragrafo, string userId);
    }
}
