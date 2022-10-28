using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentSkillOptionService : IServiceBaseT2<ComponentSkillOption>, IOptionServiceBaseT1<ComponentSkillOption>, IOptionServiceBaseT1Async<ComponentSkillOption>
    {
        ComponentSkillOption Put(string category, string description, string level, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentSkillOption> PutAsync(string category, string description, string level, string userId);
    }
}
