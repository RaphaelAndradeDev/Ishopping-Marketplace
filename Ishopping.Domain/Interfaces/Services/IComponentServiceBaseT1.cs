using Ishopping.Domain.ApplicationClass;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentServiceBaseT1<TEntity> where TEntity : class
    {
        IEnumerable<string> Search(string startsWith, int position, string userId);
        TEntity GetBySiteNumber(int siteNumber);
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
        IEnumerable<TEntity> GetAllByUserId(string userId);
        TEntity GetById(Guid id, string userId);
        TEntity GetBy(string search, int position, string userId);
        void DeleteAll(string userId);
    }
}
