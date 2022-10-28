using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentButtonOptionRepository : IRepositoryBaseT2<ContentButtonOption>, IOptionRepositoryBaseT1<ContentButtonOption>, IOptionRepositoryBaseT1Async<ContentButtonOption>
    {        
    }
}
