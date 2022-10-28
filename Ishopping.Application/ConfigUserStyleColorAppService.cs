using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Application
{
    public class ConfigUserStyleColorAppService : AppServiceBaseT2<ConfigUserStyleColor>, IConfigUserStyleColorAppService
    {
        private readonly IConfigUserStyleColorService _configUserStyleColorService;

        public ConfigUserStyleColorAppService(IConfigUserStyleColorService configUserStyleColorService)
            :base(configUserStyleColorService)
        {
            _configUserStyleColorService = configUserStyleColorService;
        }
    }
}
