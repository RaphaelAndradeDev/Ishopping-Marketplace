using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPortfolioOptionService : IServiceBaseT2<ComponentPortofolioOption>, IOptionServiceBaseT1<ComponentPortofolioOption>, IOptionServiceBaseT1Async<ComponentPortofolioOption>
    {
        ComponentPortofolioOption Put(string category, string title, string description, string list, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentPortofolioOption> PutAsync(string category, string title, string description, string list, string userId);
    }
}
