using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentTextOptionRepository : IRepositoryBaseT2<ContentTextOption>, IOptionRepositoryBaseT1<ContentTextOption>, IOptionRepositoryBaseT1Async<ContentTextOption>
    {        
    }
}
