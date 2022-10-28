using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IUserSerializeViewDataDapperRepository
    {
        UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod);             
        void Persist(UserSerializeViewData userSerializeViewData);

        // Async Methods
        Task<UserSerializeViewData> GetBySiteNumberAsync(int siteNumber, int viewCod);    
    }
}
