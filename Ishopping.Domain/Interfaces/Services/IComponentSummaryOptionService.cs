using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentSummaryOptionService : IServiceBaseT2<ComponentSummaryOption>, IOptionServiceBaseT1<ComponentSummaryOption>, IOptionServiceBaseT1Async<ComponentSummaryOption>
    {
        ComponentSummaryOption Put(string title, string catetory, string description, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentSummaryOption> PutAsync(string title, string catetory, string description, string userId);
    }
}
