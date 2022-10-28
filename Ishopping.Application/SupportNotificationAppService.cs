using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class SupportNotificationAppService : AppServiceBase<SupportNotification>, ISupportNotificationAppService
    {
        private readonly ISupportNotificationService _supportNotificationService;

        public SupportNotificationAppService(ISupportNotificationService supportNotificationService)
            :base(supportNotificationService)
        {
            _supportNotificationService = supportNotificationService;
        }
    }
}
