using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentFaqOptionService : IServiceBaseT2<ComponentFaqOption>, IOptionServiceBaseT1<ComponentFaqOption>, IOptionServiceBaseT1Async<ComponentFaqOption>
    {
        ComponentFaqOption Put(string pergunta, string resposta, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentFaqOption> PutAsync(string pergunta, string resposta, string userId);
    }
}
