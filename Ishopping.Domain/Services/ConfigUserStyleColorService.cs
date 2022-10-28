using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class ConfigUserStyleColorService : ServiceBaseT2<ConfigUserStyleColor>, IConfigUserStyleColorService
    {
        private readonly IConfigUserStyleColorRepository _configUserStyleColorRepository;

        public ConfigUserStyleColorService(IConfigUserStyleColorRepository configUserStyleColorRepository)
            : base(configUserStyleColorRepository)
        {
            _configUserStyleColorRepository = configUserStyleColorRepository;
        }
    }
}
