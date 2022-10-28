using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IConfigUserStyleClassAppService : IAppServiceBaseT2<ConfigUserStyleClass>
    {        
        ConfigUserStyleClass GetById(Guid id, string userId);
        ConfigUserStyleClass GetByClassName(string className, string userId);         
        IEnumerable<ConfigUserStyleClass> GetAllByUserId(string userId);
        JsonResponse AppUpdate(string userId, int siteNumber, string oldGoogleFonts, string googleFonts, string oldName, ConfigUserStyleClass configUserStyleClass);
        void AddRanger(IEnumerable<ConfigUserStyleClass> configUserStyleClass);        
        void DeleteAll(string userId);

        // Async Methods
        Task<IEnumerable<string>> GetAllClassNameAsync(string userId);
        Task<ConfigUserStyleClass> GetByIdAsync(Guid id, string userId);
        Task<ConfigUserStyleClass> GetByClassNameAsync(string className, string userId);
        Task<IEnumerable<ConfigUserStyleClass>> GetAllByUserIdAsync(string userId);        
        Task<JsonDelete> AppDeleteAsync(string id, string userId);

    }
}
