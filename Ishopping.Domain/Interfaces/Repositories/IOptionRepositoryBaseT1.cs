using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IOptionRepositoryBaseT1<TEntity> where TEntity : class
    {     
        IEnumerable<TEntity> GetAllByUserId(string userId);
        TEntity GetById(Guid id, string userId);
        TEntity GetDefault(string userId);
    }
}
