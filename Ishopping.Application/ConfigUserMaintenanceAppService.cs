using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Common.ConfigGlobal;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;

namespace Ishopping.Application
{
    public class ConfigUserMaintenanceAppService : AppServiceBaseT2<ConfigUserMaintenance>, IConfigUserMaintenanceAppService
    {  
        private readonly IConfigUserMaintenanceService _configUserMaintenanceService;  

        public ConfigUserMaintenanceAppService(        
            IConfigUserMaintenanceService configUserMaintenanceService)
            :base(configUserMaintenanceService)
        {   
            _configUserMaintenanceService = configUserMaintenanceService; 
        }

        public ConfigUserMaintenance GetByUserId(string userId)
        {
            return _configUserMaintenanceService.GetByUserId(userId);
        }

        public ConfigUserMaintenance GetBySiteNumber(int siteNumber)
        {
            return _configUserMaintenanceService.GetBySiteNumber(siteNumber);
        }

        public bool GetIsMaintenance(string userId)
        {
            return _configUserMaintenanceService.GetIsMaintenance(userId);
        }

        public void RemoveMaintenance()
        {
            // Checa e remove todos os profiles em manutenção
            _configUserMaintenanceService.RemoveMaintenance();
        }

        public JsonResponse AppUpdate(string userId, string title, string message, string dateReturn, string viewName, string partialView, bool isMaintenance)
        {         
            JsonResponse json = new JsonResponse();

            DateTime dateTime = Timezone.ThisDateTime(Convert.ToDateTime(dateReturn));
            bool maintenanceIsValid = MaintenanceIsValid(isMaintenance, dateTime);
            if (isMaintenance && !maintenanceIsValid)
            {
                json.Serialize = false;
                json.Message = "A data de retorno deve ter no mínimo 30 minutos sobre a hora atual";
                return json; 
            }

            var maintenance = _configUserMaintenanceService.GetByUserId(userId);           
            maintenance.Change(maintenanceIsValid, viewName, partialView, title, dateTime, message);
            _configUserMaintenanceService.Update(maintenance);        
                   
            json.Serialize = false;
            json.Id = maintenance.Id.ToString();
            return json;           
        }

        private bool MaintenanceIsValid(bool isMaintenance, DateTime dateReturn)
        {
            if(isMaintenance)
            {
                TimeSpan time = dateReturn.Subtract(DateTime.Now);                
                return time.TotalMinutes >= 30;
            }
            return false;
        }
               
    }
}
