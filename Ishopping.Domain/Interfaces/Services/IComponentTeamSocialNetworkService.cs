using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentTeamSocialNetworkService : IServiceBaseT2<ComponentTeamSocialNetwork>
    {
        ComponentTeamSocialNetwork GetById(Guid id, string userId);
        AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod);
        void DeleteAll(Guid componentTeamId);

        // Async Methods
        Task<ComponentTeamSocialNetwork> GetByIdAsync(Guid id, string userId);
    }
}
