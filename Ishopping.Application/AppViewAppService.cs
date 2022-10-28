using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class AppViewAppService : AppServiceBase<AppView>, IAppViewAppService
    {
        private readonly IAppViewService _appViewService;

        public AppViewAppService(IAppViewService appViewService)
            :base(appViewService)
        {
            _appViewService = appViewService;
        }

        public IEnumerable<AppView> GetAllByType(int type)
        {
            return _appViewService.GetAllByType(type);
        }
    }
}
