using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class SupportErrorAppService : AppServiceBase<SupportError>, ISupportErrorAppService
    {
        private readonly ISupportErrorService _supportErrorService;

        public SupportErrorAppService(ISupportErrorService supportErrorService)
            :base(supportErrorService)
        {
            _supportErrorService = supportErrorService;
        }
    }
}
