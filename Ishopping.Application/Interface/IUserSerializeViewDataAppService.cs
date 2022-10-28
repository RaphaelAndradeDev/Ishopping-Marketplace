using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IUserSerializeViewDataAppService : IAppServiceBaseT2<UserSerializeViewData>
    {
        UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod);
        bool IsMaintenance(int siteNumber);
        void Persist(string userId, int siteNumber, int viewCod, string serialize);

        // Async Methods
        Task<UserSerializeViewData> GetBySiteNumberAsync(int siteNumber, int viewCod);
    }
}
