using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IConfigUserDisplayAppService : IAppServiceBaseT2<ConfigUserDisplay>
    {
        ConfigUserDisplay GetByUserId(string userId);
        ConfigUserDisplay GetByImageId(Guid imageId);
        ConfigUserDisplay GetBySiteNumber(int siteNumber);
        JsonResponse AppUpdate(string userId, string title, string message, string imageFileName);
        void ConfigUserDisplayProfileUpdate(UserRegisterProfile userRegisterProfile);
        void ConfigUserDisplayPlanUpdate(string userId, string action, string controller, bool blocked, int displayValue, bool maintenance);

        // Async Methods
        Task<ConfigUserDisplay> GetByUserIdAsync(string userId);
        Task<ConfigUserDisplay> GetByImageIdAsync(Guid imageId);
        Task<ConfigUserDisplay> GetBySiteNumberAsync(int siteNumber);
        Task<IEnumerable<ConfigUserDisplay>> GetAllByGeolocationAsync(double latitude, double longitude);
        Task<IEnumerable<ConfigUserDisplay>> GetBySearchAsync(string semantic, string address);
        Task<IEnumerable<ConfigUserDisplay>> GetSpecificAsync(string specific);
        Task<IEnumerable<string>> SearchBySemanticAsync(string term);
        Task<IEnumerable<string>> SearchByAddressAsync(string term);
        Task<IEnumerable<string>> SearchSpecificAsync(string term);
        Task<IEnumerable<string>> SearchSpecificAdressAsync(string term);
    }
}
