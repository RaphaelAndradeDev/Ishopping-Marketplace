using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class SupportNotificationService : ServiceBase<SupportNotification>, ISupportNotificationService
    {
        private readonly ISupportNotificationRepository _supportNotificationRepository;

        public SupportNotificationService(ISupportNotificationRepository supportNotificationRepository)
            :base(supportNotificationRepository)
        {
            _supportNotificationRepository = supportNotificationRepository;
        }
    }
}
