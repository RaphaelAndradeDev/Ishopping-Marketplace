using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserSerializeViewDataService : IServiceBaseT2<UserSerializeViewData>
    {
        UserSerializeViewData GetByUserId(string userId, int viewCod);
        IEnumerable<UserSerializeViewData> GetAllByUserId(string userId);
        UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod);
        IEnumerable<UserSerializeViewData> GetAllBySiteNumber(int siteNumber);    
        void Persist(UserSerializeViewData userSerializeViewData);
        void RemoveAll(int siteNumber);

        // Async Methods
        Task<UserSerializeViewData> GetBySiteNumberAsync(int siteNumber, int viewCod);       
    }
}
