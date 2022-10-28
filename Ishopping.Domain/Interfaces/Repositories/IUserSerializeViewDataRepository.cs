using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserSerializeViewDataRepository : IRepositoryBaseT2<UserSerializeViewData>
    {
        UserSerializeViewData GetByUserId(string userId, int viewCod);
        IEnumerable<UserSerializeViewData> GetAllByUserId(string userId);
        UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod);
        IEnumerable<UserSerializeViewData> GetAllBySiteNumber(int siteNumber);    
        void RemoveAll(int siteNumber);
    }
}
