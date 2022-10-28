using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Update(IEnumerable<TEntity> obj);
        void Remove(TEntity obj);
        void Dispose();
    }

    public interface IRepositoryBaseT2<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Update(IEnumerable<TEntity> obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
