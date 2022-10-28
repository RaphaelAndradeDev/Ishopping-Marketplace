
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected IshoppingContext db = new IshoppingContext();

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> obj)
        {
            foreach (var item in obj)
            {
                db.Entry(item).State = EntityState.Modified;
            }            
            db.SaveChanges();
        }
        
        public void Remove(TEntity obj)
        {
            if (obj != null)
            {
                db.Set<TEntity>().Remove(obj);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    public class RepositoryBaseT2<TEntity> : IDisposable, IRepositoryBaseT2<TEntity> where TEntity : class
    {
        protected IshoppingContext db = new IshoppingContext();

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {           
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();            
        }

        public void Update(IEnumerable<TEntity> obj)
        {
            foreach (var item in obj)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            if(obj != null)
            {
                db.Set<TEntity>().Remove(obj);
                db.SaveChanges();
            }            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
