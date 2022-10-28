using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IConfigUserAppearanceService : IServiceBaseT2<ConfigUserAppearance>
    {
        ConfigUserAppearance GetByUserId(string userId);
        ConfigUserAppearance GetBySiteNumber(int siteNumber);

        // Async Methods
        Task<ConfigUserAppearance> GetByUserIdAsync(string userId);
        Task<ConfigUserAppearance> GetBySiteNumberAsync(int siteNumber);
    }
}
