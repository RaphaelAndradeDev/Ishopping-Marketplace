using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentTeamOptionRepository : IRepositoryBaseT2<ComponentTeamOption>, IOptionRepositoryBaseT1<ComponentTeamOption>, IOptionRepositoryBaseT1Async<ComponentTeamOption>
    {        
    }
}
