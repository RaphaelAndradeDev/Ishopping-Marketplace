using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IOptionServiceBaseT1<TEntity> where TEntity : class
    {     
        IEnumerable<TEntity> GetAllByUserId(string userId);
        TEntity GetById(Guid id, string userId);
        TEntity GetDefault(string userId);
    }
}
