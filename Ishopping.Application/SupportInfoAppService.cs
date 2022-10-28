using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class SupportInfoAppService : AppServiceBase<SupportInfo>, ISupportInfoAppService
    {
        private readonly ISupportInfoService _supportInfoService;

        public SupportInfoAppService(ISupportInfoService supportInfoService)
            :base(supportInfoService)
        {
            _supportInfoService = supportInfoService;
        }
    }
}
