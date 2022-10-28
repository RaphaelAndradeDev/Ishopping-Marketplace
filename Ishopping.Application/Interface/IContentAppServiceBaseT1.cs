using System;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IContentAppServiceBaseT1<TEntity> where TEntity : class
    {       
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber, int maxPosition);
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod);
        IEnumerable<TEntity> GetAllByUserId(string userId);
        IEnumerable<TEntity> GetAllByUserId(string userId, int maxPosition);
        IEnumerable<TEntity> GetAllByUserId(string userId, int maxPosition, int viewCod);
        TEntity GetById(Guid id, string userId);
        TEntity GetBy(int viewCod, int position, string userId);       
        void DeleteAll(string userId);
    }
}
