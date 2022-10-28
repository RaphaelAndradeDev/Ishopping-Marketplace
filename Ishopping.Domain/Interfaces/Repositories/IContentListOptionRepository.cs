using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentListOptionRepository : IRepositoryBaseT2<ContentListOption>, IOptionRepositoryBaseT1<ContentListOption>, IOptionRepositoryBaseT1Async<ContentListOption>
    {        
    }
}
