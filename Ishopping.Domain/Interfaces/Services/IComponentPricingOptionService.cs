using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPricingOptionService : IServiceBaseT2<ComponentPricingOption>, IOptionServiceBaseT1<ComponentPricingOption>, IOptionServiceBaseT1Async<ComponentPricingOption>
    {
        ComponentPricingOption Put(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price, string userId);
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);

        // Async Methods
        Task<ComponentPricingOption> PutAsync(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price, string userId);
    }
}
