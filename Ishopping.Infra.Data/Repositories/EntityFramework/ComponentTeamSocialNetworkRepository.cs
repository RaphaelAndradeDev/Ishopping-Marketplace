using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentTeamSocialNetworkRepository : RepositoryBaseT2<ComponentTeamSocialNetwork>, IComponentTeamSocialNetworkRepository
    {
        public ComponentTeamSocialNetwork GetById(Guid id, string userId)
        {
            return db.ComponentTeamSocialNetwork.FirstOrDefault(x => x.Id == id && x.ComponentTeam.IdUser == userId);
        }

        public void DeleteAll(Guid componentTeamId)
        {
            var listTeamSocialNetwork = db.ComponentTeamSocialNetwork.Where(x => x.ComponentTeamId == componentTeamId).ToList();
            db.ComponentTeamSocialNetwork.RemoveRange(listTeamSocialNetwork);
            db.SaveChanges();
        } 

        // Async Methods
        public async Task<ComponentTeamSocialNetwork> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentTeamSocialNetwork.FirstOrDefaultAsync(x => x.Id == id && x.ComponentTeam.IdUser == userId);
        }    
    }
}
