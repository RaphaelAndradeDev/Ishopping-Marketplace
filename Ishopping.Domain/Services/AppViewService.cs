using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AppViewService : ServiceBase<AppView>, IAppViewService
    {
        private readonly IAppViewRepository _appViewRepository;

        public AppViewService(IAppViewRepository appViewRepository)
            : base(appViewRepository)
        {
            _appViewRepository = appViewRepository;
        }

        public IEnumerable<AppView> GetAllByType(int type)
        {
            return _appViewRepository.GetAllByType(type);
        }
    }
}
