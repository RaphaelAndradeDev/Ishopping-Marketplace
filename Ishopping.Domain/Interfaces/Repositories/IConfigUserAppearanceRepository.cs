using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IConfigUserAppearanceRepository : IRepositoryBaseT2<ConfigUserAppearance>
    {
        ConfigUserAppearance GetByUserId(string userId);
        ConfigUserAppearance GetBySiteNumber(int siteNumber);

        // Async Methods
        Task<ConfigUserAppearance> GetByUserIdAsync(string userId);
        Task<ConfigUserAppearance> GetBySiteNumberAsync(int siteNumber);
    }
}
