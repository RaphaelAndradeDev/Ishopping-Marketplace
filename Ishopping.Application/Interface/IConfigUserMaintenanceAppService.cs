using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IConfigUserMaintenanceAppService : IAppServiceBaseT2<ConfigUserMaintenance>
    {
        ConfigUserMaintenance GetByUserId(string userId);
        ConfigUserMaintenance GetBySiteNumber(int siteNumber);
        bool GetIsMaintenance(string userId);
        void RemoveMaintenance();
        JsonResponse AppUpdate(string userId, string title, string message, string dateReturn, string viewName, string partialView, bool isMaintenance);
    }
}
