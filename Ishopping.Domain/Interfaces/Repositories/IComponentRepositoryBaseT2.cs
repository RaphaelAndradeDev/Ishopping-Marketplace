using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentRepositoryBaseT2<TEntity> where TEntity : class
    {
        IEnumerable<string> Search(string startsWith, string userId);
        TEntity GetBySiteNumber(int siteNumber);
        IEnumerable<TEntity> GetAllBySiteNumber(int siteNumber);
        IEnumerable<TEntity> GetAllByUserId(string userId);
        TEntity GetById(Guid id, string userId);
        TEntity GetByTerm(string term, string userId);      
        void DeleteAll(string userId);
    }
}
