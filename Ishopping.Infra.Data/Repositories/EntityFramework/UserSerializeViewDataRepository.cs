using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories.EntityFramework
{
    public class UserSerializeViewDataRepository : RepositoryBaseT2<UserSerializeViewData>, IUserSerializeViewDataRepository
    {
        public UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod)
        {
            return db.UserSerializeViewData.FirstOrDefault(x => x.SiteNumber == siteNumber && x.ViewCod == viewCod);
        }
        
        public IEnumerable<UserSerializeViewData> GetAllBySiteNumber(int siteNumber)
        {
            return db.UserSerializeViewData.Where(x => x.SiteNumber == siteNumber);
        }       
       
        public UserSerializeViewData GetByUserId(string userId, int viewCod)
        {
            return db.UserSerializeViewData.FirstOrDefault(x => x.IdUser == userId && x.ViewCod == viewCod);
        }

        public IEnumerable<UserSerializeViewData> GetAllByUserId(string userId)
        {
            return db.UserSerializeViewData.Where(x => x.IdUser == userId);
        }

        public void RemoveAll(int siteNumber)
        {
            var serialize = GetAllBySiteNumber(siteNumber);
            if (serialize != null)
            {
                db.UserSerializeViewData.RemoveRange(serialize);
                db.SaveChanges();
            }
        }
    }
}
