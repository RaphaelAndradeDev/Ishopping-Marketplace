using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IConfigUserDisplayRepository : IRepositoryBaseT2<ConfigUserDisplay>
    {
        ConfigUserDisplay GetByUserId(string userId);
        ConfigUserDisplay GetByImageId(Guid imageId);
        ConfigUserDisplay GetBySiteNumber(int siteNumber);
        void SetIsMaintenance(string userId, bool isMaintenance);

        // Async Methods
        Task<ConfigUserDisplay> GetByUserIdAsync(string userId);
        Task<ConfigUserDisplay> GetByImageIdAsync(Guid imageId);
        Task<ConfigUserDisplay> GetBySiteNumberAsync(int siteNumber);
    }
}
